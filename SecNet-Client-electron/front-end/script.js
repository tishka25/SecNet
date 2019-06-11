var electron = null;
var serialPortList = null;
var baudRatesList = null;

window.addEventListener("load" , function(){  
    electron = require("electron").remote.require("./index.js");
    serialPortList = this.document.getElementById("serial-port-list");
    baudRatesList = document.getElementById("baud-rates-list");

    atachEvents();

    electron.getSerialPorts(data=>{
        // this.console.log(data);
        for(var port of data){
            var portName = port.comName;
            var option = this.document.createElement('option');
            option.value = portName;
            option.innerHTML = portName;
            serialPortList.appendChild(option);
        }
    });
});


const atachEvents = function(){
    document.getElementById("connectButton").addEventListener("click" , connectToDevice);
    document.getElementById("disconnectButton").addEventListener("click" , disconnectDevice);
        
}

const connectToDevice = function(){
    electron.connectToSerialPort(serialPortList.value , parseInt(baudRatesList.value) , onDataReceived);
}
const disconnectDevice = function(){
    console.log("Disconnecting")
    electron.disconnectDevice((data)=>{
        document.getElementById("incomingData").value += "\n" + data
    });
};

const onDataReceived = function(data){
    document.getElementById("incomingData").value += "\n" + data
}