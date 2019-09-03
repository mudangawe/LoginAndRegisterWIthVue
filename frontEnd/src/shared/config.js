import assets from "./assets";

export default{
    appURL: String,
    serviceURL: String,

    getConfig(){
        this.appURL = assets.config.appURL;
        this.serviceURL = assets.config.serviceURL;
    }
};