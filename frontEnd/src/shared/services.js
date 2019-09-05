import Configuration from "./config";


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
        return JSON.parse(await post("https://localhost:44332/api/login",application,true));
    },

    getApplication: async function () {
        return JSON.parse(await get(`https://localhost:44332/api/login`, true));
    }
}