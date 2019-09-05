<template>
   <section aria-label="Form">
              <div>
                  <div>
                      <label class = "row" id="default">Name: </label>
                      <input v-model="profile.Name"  class = "row" id="default"/>
                      <span class="row text-danger text-danger" v-if="error[0]">Name required</span>
                  </div>
                  <div >
                      <label class = "row">Surname: </label>
                      <input class = "row" id="default" v-model="this.profile.Surname" />
                      <span class="row text-danger" v-if="error[1]">Surname required</span>
                  </div>
                  <div >
                      <label class = "row">Email: </label>
                      <input  v-model="profile.Email" class = "row"/>
                      <span class="row text-danger" v-if="error[2]">{{errorEmail}}</span>
                  </div>
                  <div >
                      <label class = "row">Contact: </label>
                      <input  v-model="profile.Contact" class = "row"/>
                      <span class="row text-danger" v-if="error[3]">{{errorNumber}}</span>
                  </div>
                  <div >
                      <label class = "row" >Address: </label>
                      <input  id="default" v-model="profile.Address" class = "row"/>
                      <span class="row text-danger" v-if="error[4]"> Address required </span>
                  </div>
                  <div >
                      <label class = "row">Password: </label>
                      <input  class = "row" id="default"  type="password" v-model="profile.Password"/>
                      <span class="row text-danger" v-if="error[5]"> {{errorPassword}} </span>
                  </div>
                  <div >
                      <label class = "row" >Re-Password: </label>
                      <input v-model="profile.RePassword"  type="password" id="default" class = "row" />
                      <span class="row text-danger" v-if="error[6]">{{rePassword}}</span>
                  </div>
              </div>
               <div class = "row">
              <input  type="submit" value="Submit" @click="VerifyInput()" />
              </div>
         
      </section>
</template>



<script>
import services from "../shared/services";
export default {
    name:"register",
    props:{},
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
            error:[false,false,false,false,false,false,false],
            errorEmail:null,
            rePassword:null,
            errorNumber:null,
            errorPassword:null,
            info:null
        }
    },
    computed:{

    },
    methods:{
         validEmail: function (email) {
          var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
          return re.test(email);},

        VerifyInput(){
            if(this.profile.Name == null)
            {
                this.error[0] = true;
            }
            else
            {
                this.error[0] = false;
            }
            if(this.profile.Surname == null)
            {
                this.error[1] = false;
            }
            else
            {
                this.error[1] = false;
            }
            if(this.profile.Email == null)
            {
                this.error[2] = true;
                this.errorEmail = "Email required"
            }
            else
            {
               if(this.validEmail(this.profile.email))
                {
                   this.error[2] = true;
                 }
                 else
                 {
                     this.errorEmail = "Enter valid Email"
                 }
            }
            if(this.profile.Contact == null)
            {
                this.error[3] = true;
                this.errorNumber ="Number is required"
            }
            else
            {
                this.error[3] = false;
            }

             if(this.profile.Address == null)
            {
                this.error[4] = true;
            }
            else
            {
                this.error[4] = false;
            }
            if(this.profile.Password == null)
            {
                this.error[5] = true;
                
            }
            else
            {
                this.error[5] = false;
            }
            if(this.profile.RePassword == null)
            {
                this.error[6] = true;
                this.rePassword = "Repeat your password"
            }
            else
            {
                if(this.profile.RePassword == this.profile.Password)
                {
                     this.error[6] = true;
                }
                else
                {
                     this.rePassword = "Password does not match"
                }
            }
            
        },
        
        async save() {
            
            try { 
                this.changePage = await services.postApplication(this.profile);
            }
            catch(error) {
               alert(error, "Failed to save application", error);
            }
        }
    }
}
</script>

<style>


  
</style>