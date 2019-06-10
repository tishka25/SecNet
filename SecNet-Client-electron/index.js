const Serialport = require('serialport');

const serialport = new Serialport("/dev/tty.usbserial-A925H3JZ" , {baudRate:115200});

//Type of authentifications
const USER = "22";
const ADMIN = "36";
const OKS = "13";
//

var passwords = {
    "22":"123456",
    "36":"456123",
    "13":"999"
}



//The type of user authentifaction starts with the prepend command "$$"
const typeOfAuthCommand = "$$";
//
//Before the entered password the Nextion display prepends the command "##"
const passwordCommand = "##";
//

var currentAuth = "";

serialport.on("data" , (data)=>{
    var stringData = data.toString();
    console.log("Raw data: " + stringData);
    if(stringData.startsWith(typeOfAuthCommand)){
        currentAuth = stringData.slice(2 , stringData.lenght);
        console.log("Correct password for this user is: " , passwords[currentAuth]);
    }

    if(stringData.startsWith(passwordCommand)){
        var currentPassword = stringData.slice(2 , stringData.lenght);
        console.log("Entered password: " + currentPassword , " ; ","Correct password: " + passwords[currentAuth]);
        if(currentPassword == passwords[currentAuth]){
            var buff = new Buffer("page successPage\xFF\xFF\xFF" , 'ascii');
            serialport.write(buff);        
        }else{
            var buff = new Buffer("page failurePage\xFF\xFF\xFF" , 'ascii');
            serialport.write(buff);        
        }
    }
});