const Serialport = require('serialport');
const { app, BrowserWindow } = require("electron");



//Current serial device 
var serialport = null;
//

//Type of authentifications
const USER = "22";
const ADMIN = "36";
const OKS = "13";
//

var passwords = {
  "22": "123456",
  "36": "456123",
  "13": "999"
}



//The type of user authentifaction starts with the prepend command "$$"
const typeOfAuthCommand = "$$";
//
//Before the entered password the Nextion display prepends the command "##"
const passwordCommand = "##";
//

var currentAuth = "";


let mainWindow

function createWindow() {
  // Create the browser window.
  mainWindow = new BrowserWindow({
    width: 800, height: 600,
    webPreferences: {
      nodeIntegration: true
    }
  })

  // and load the index.html of the app.
  mainWindow.loadFile("./front-end/index.html");

  // Open the DevTools.
  mainWindow.webContents.openDevTools()

  // Emitted when the window is closed.
  mainWindow.on('closed', function () {
    // Dereference the window object, usually you would store windows
    // in an array if your app supports multi windows, this is the time
    // when you should delete the corresponding element.
    mainWindow = null
  })
}

// This method will be called when Electron has finished
// initialization and is ready to create browser windows.
// Some APIs can only be used after this event occurs.
app.on('ready', createWindow)

// Quit when all windows are closed.
app.on('window-all-closed', function () {
  // On OS X it is common for applications and their menu bar
  // to stay active until the user quits explicitly with Cmd + Q
  app.quit()
})

app.on('activate', function () {
  // On OS X it's common to re-create a window in the app when the
  // dock icon is clicked and there are no other windows open.
  if (mainWindow === null) {
    createWindow()
  }
})


exports.getSerialPorts = (onReady, onError) => {
  Serialport.list(function (err, ports) {
    if (err) {
      console.log(err);
      onError(err);
      return;
    } else {
      onReady(ports);
      console.log(ports);
    }
  });
}

exports.connectToSerialPort = (portName, baudRate , onDataReceived) => {
  serialport = new Serialport(portName, { baudRate: baudRate } , (err , data)=>{
    if(err){
      onDataReceived(err);
      return;
    }else{
      onDataReceived("Connected to " + portName);
    }
  });

  serialport.on("data", (data) => {
    var stringData = data.toString();
    onDataReceived(stringData);
    console.log("Raw data: " + stringData);
    if (stringData.startsWith(typeOfAuthCommand)) {
      currentAuth = stringData.slice(2, stringData.lenght);
      console.log("Correct password for this user is: ", passwords[currentAuth]);
    }
    if (stringData.startsWith(passwordCommand)) {
      var currentPassword = stringData.slice(2, stringData.lenght);
      console.log("Entered password: " + currentPassword, " ; ", "Correct password: " + passwords[currentAuth]);
      if (currentPassword == passwords[currentAuth]) {
        var buff = new Buffer("page successPage\xFF\xFF\xFF", 'ascii');
        serialport.write(buff);
      } else {
        var buff = new Buffer("page failurePage\xFF\xFF\xFF", 'ascii');
        serialport.write(buff);
      }
    }
  });
};

exports.disconnectDevice = (onDisconnect)=>{
  serialport.close(onDisconnect("Disconnected..."));
}