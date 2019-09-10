<template>
   <section aria-label="Form">
              <div>
                  <div>
                      <label class = "row" >Name: </label>
                      <input v-model="profile.Name"  class = "row" />
                      <span class="row text-danger text-danger" v-if="error[0]">Name required</span>
                  </div>
                  <div >
                      <label class = "row">Surname: </label>
                      <input class = "row"  v-model="profile.Surname" />
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
                      <input   v-model="profile.Address" class = "row"/>
                      <span class="row text-danger" v-if="error[4]"> Address required </span>
                  </div>
                  <div >
                      <label class = "row">Password: </label>
                      <input  class = "row"   type="password" v-model="profile.Password"/>
                      <span class="row text-danger" v-if="error[5]"> {{errorPassword}} </span>
                  </div>
                  <div >
                      <label class = "row" >Re-Password: </label>
                      <input v-model="profile.RePassword"  type="password"  class = "row" />
                      <span class="row text-danger" v-if="error[6]">{{rePassword}}</span>
                  </div>
              </div>
               <div class = "row">
              <input  type="submit" value="Submit" @click="VerifyInput()" :disabled="isDisable" />
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
            qualityInput:[true,true,true,true,false,true,true],
            errorEmail:null,
            rePassword:null,
            errorNumber:null,
            errorPassword:null,
            
        }
    },
    computed:{
            isDisable(){
                return (this.error.every(this.isAllVerified))
            },
           


    },
    methods:{
        isPasswordCorrect(password){
        var strongRegex = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})");
        return strongRegex.test(password);
        },
         isAllVerified(arr){
             return arr==false;
         },
         isEmailvalid: function () {
          var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
          return re.test(this.profile.Email);},
         isNumberValid(){
             var regexNumber =/^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
             return regexNumber.test(this.profile.Contact);
         },
        VerifyInput(){
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
    },
    watch:{
        'profile.Name'(){
            if(!this.profile.Name)
            {
                this.error[0] = true;
                this.qualityInput[0] = true;
            }
            else
            {
                this.qualityInput[0] = false;
                this.error[0] = false;
            }
        },
        'profile.Surname'(){  
            if(!this.profile.Surname)
            {
                this.qualityInput[1] = true;
                this.error[1] = true;
            }
            else
            {
                this.qualityInput[1] = false;
                this.error[1] = false;
            }},
        'profile.Email'(){
                if(!this.profile.Email)
                {
                    this.error[2] = true;
                    this.errorEmail = "Email required";
                    this.qualityInput[2] = true;
                }
                else
                {
                    if(this.isEmailvalid())
                    {
                      this.error[2] = false;
                      this.qualityInput[2] = false;
                    }
                    else
                    {
                        this.errorEmail = "Enter valid Email";
                        this.error[2] = true;
                        this.qualityInput[2] = true;
                    }
                }
            },
            'profile.Contact'(){ 
                if(this.profile.Contact == null)
                {
                    this.error[3] = true;
                    this.errorNumber ="Number is required"
                }
                else
                {
                    if(this.isNumberValid())
                    {
                         this.error[3] = false;
                         this.qualityInput[3] = false;
                    }
                    else
                    {
                        this.error[3] = true;
                        this.qualityInput[3] = true;
                        this.errorNumber ="Enter valid number"
                    }
               }
            
            },
            'profile.Password'(){
             if(!this.profile.Password)
             {
                this.errorPassword = "Password is requred";
                this.error[5] = true;  
                this.qualityInput[5] = true;              
             }
             else
             {
                 if(this.isPasswordCorrect(this.profile.Password))
                 {
                    this.error[5] = false;  
                    this.qualityInput[5] = false;   
                 }
                 else
                 {
                    this.errorPassword = "Enter valid password";
                    this.qualityInput[5] = true;  
                    this.error[5] = true;
                 }
             }
            },
            'profile.RePassword'(){
            if(!this.profile.RePassword)
             {
                this.rePassword = "Re-Enter your password here";
                this.error[6] = true;  
                this.qualityInput[6] = true;              
             }
             else{
                 if(this.isPasswordCorrect(this.profile.RePassword) && this.profile.RePassword == this.profile.Password)
                 {
                      this.qualityInput[6] = false;
                      this.error[6] = false; 
                 }
                 else
                 {
                       this.qualityInput[6] = true;
                       this.rePassword = "Password does not match";
                 }
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

</script>

<style>


  
</style>