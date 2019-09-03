<template>
   <section aria-label="Form">
         
              <legend>Register New User </legend>
              <div>
                  <div>
                      <label class = "row" id="default">Name: </label>
                      <input v-model="profile.Name"  class = "row" id="default"/>
                  </div>
                  <div >
                      <label class = "row">Surname: </label>
                      <input class = "row" id="default" v-model="profile.Surname" />
                  </div>
                  <div >
                      <label class = "row">Email: </label>
                      <input  v-model="profile.Email" class = "row"/>
                  </div>
                  <div >
                      <label class = "row">Contact: </label>
                      <input  v-model="profile.Contact" class = "row"/>
                  </div>
                  <div >
                      <label class = "row" >Address: </label>
                      <input  id="default" v-model="profile.Address" class = "row"/>
                  </div>
                  <div >
                      <label class = "row">Password: </label>
                      <input  class = "row" id="default"  type="password" v-model="profile.Password"/>
                  </div>
                  <div >
                      <label class = "row" >Re-Password: </label>
                      <input v-model="profile.RePassword"  type="password" id="default" class = "row" />
                  </div>
              </div>
               <div class = "row">
              <input  type="submit" value="Submit" @click="CreatePost" />
              </div>
         
      </section>
</template>



<script>

export default {
    name:"register",
    data(){
        return{
            profile:{
                Name:null,
                Surname:null,
                Email:null,
                Contact:null,
                Address:null,
                Password:null,
                RePassword:null

            },
            info:null
        }
    }, 
    methods:{
        VerifyInput(){

        },
         CreatePost(){
            var xhr = new XMLHttpRequest();
            xhr.open("POST", 'https://localhost:44332/api/login');
                //Send the proper header information along with the request
            
            xhr.onreadystatechange = function() { // Call a function when the state changes.
            if (this.readyState === 4 && this.status === 200) {
                alert(this.response)
             }
           }
           xhr.setRequestHeader('Content-type', 'application/json');
           xhr.send(JSON.stringify(this.profile));
           alert(JSON.stringify(this.profile));
            }
    }
}
</script>

<style>


  
</style>