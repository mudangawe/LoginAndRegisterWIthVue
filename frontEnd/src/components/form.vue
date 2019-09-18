<template>
  <section aria-label="Form">
   
    <div class="form-group row">
    <label  class="col-sm-3 col-form-label">Email<span v-if="isEmailvalid" class="  text-danger">*</span></label>
    <div class="col-sm-8">
      <input type="email" class="form-control" v-model="email" placeholder="Email">
    </div>
  </div>
    <div class="form-group row">
        <label  class="col-sm-3 col-form-label">Password <span v-show="isPasswordValid" class="text-danger">*</span>
        </label>
        <div class="col-sm-8">
          <input type="password" class="form-control" v-model="password" placeholder="Password">
        </div>
    </div>
   
     <div class="form-group row">
    <div class="col-sm-10">
      <input type="Submit" text="Submit" @click="VerifyInput"  :disabled="isDisabled"/>
     </div>
  </div>
  <message ref="child"></message>
  </section>
</template>

<script>

import services from "../shared/services";
import message from "./dialogs/message";
export default {
  components:{
    message
  },
  name: "loginForm",
  data() {
    return {
      userData:null,
      email: null,
      password: null,
      isPasswordValid: false,
      isEmailvalid: false,
      isPasswordVerified: false,
      isEmailVerified: false,
      isPasswordRules:false,
      passwordRules:[{message:"Password must have 6 length of character"},
                     {message:"Password must have atleast one upper case letter"},
                     {message:"Password must have atleast one lower case letter"}
                    ],
      changePage:null        
    }
  },
  
 computed: {
   isDisabled(){
     return !(this.isPasswordVerified && this.isEmailVerified);
   }
  },
  
  methods: {
    respondToUser(){
        alert(this.changePage);
        if(this.changePage)
        {
          this.$emit("submit", true);
         
          this.isPasswordRules = false;
        }
        else
        {
          this.isPasswordRules = true;
        }
    },
      isEmailValidInput: function () {
          var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
          return re.test(this.email);}
      ,
      isPasswordCorrect(password){
        var strongRegex = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})");
        return strongRegex.test(password);
      },
      VerifyInput(){
            if(!this.isPasswordValid && !this.isEmailvalid &&  this.isPasswordVerified && this.isEmailVerified )
            {
                   this.isPasswordRules = false;
                   let resp = this.save();
            }
           
        },

        async save() {
            const userdate ={
              email: this.email,
              password: this.password
            }
            try { 
                this.userData = await services.postApplication(userdate);
                this.$refs.child.showModal("Feedback", this.userData.message);
            }
            catch(error) {
               alert(error, "System failure", error);
            }
        }
        
        },
        watch: {
          email(){
          
            if(!this.email)
            {
              this.isEmailvalid = true;
              this.isEmailVerified=false;
              
            }
             else if(this.isEmailValidInput())
            {
                  this.isEmailVerified=true;
                  this.isEmailvalid = false;
            }
            else 
            { this.isEmailvalid = true;
              this.isEmailVerified=false;}
          },
          password(){
            if(!this.password)
            {
              this.isPasswordValid = true;
              
              this.isPasswordVerified = false
            }
            else if(!this.isPasswordCorrect(this.password))
            {
               this.isPasswordValid = true;
               this.isPasswordVerified = false
            }
            else 
            { this.isPasswordValid = false;
              this.isPasswordVerified = true
            }
          }
        }
  }; 

</script>

<style>
#FormDesign {
  text-align: center;
  height: 50%;
  margin: 5%;
}
#FormDesignol legend ol li {
  margin: 20px;
  
}
.row{
  margin: 20px;
}
</style>