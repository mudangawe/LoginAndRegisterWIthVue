import Configuration from "./config";
import { resolve } from "dns";
import { reject } from "q";

let post = function(url,body,async)
{
    return new Promise((resolve,reject) => {
        let http = new XMLHttpRequest();
        http.onreadystatechange = function(){
            if(http.readyState==4)
            {
                if(http.status == 200)
                {
                    resolve(http.response);
                }
                else{
                    reject(http.response);
                }
            }
        }
        http.open('POST',url,async);
        http.response = 'text';
        http.setRequestHeader('Content-type','application/json');
        http.send(JSON.stringify(body));
    }
    );

}

let get = function (url, async) {
    return new Promise((resolve, reject) => {
        let http = new XMLHttpRequest();

        http.onreadystatechange = function () {
            if (http.readyState == 4) {
                if (http.status == 200) {
                    resolve(http.responseText);
                }
                else {
                    reject(http.response);
                }
            }
        }

        http.open('GET', url, async);
        http.responseType = 'text';
        http.send();
    });
}

export default{
    postApplication: async function(application){
        return JSON.parse(await post(`${Configuration.serviceURL}/api/login`,application,true));
    },

    getApplication: async function (userToken) {
        return JSON.parse(await get(`${Configuration.serviceURL}/api/login`, true));
    }
}