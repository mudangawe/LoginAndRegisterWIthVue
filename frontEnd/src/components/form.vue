<template>
  <section aria-label="Form">
    <div class="form-group row" v-if="isPasswordRules">
    
       <ul id="passwordrules">
          <li v-for="item in passwordRules" v-bind:key="item.id">
          {{ item.message }}
        </li>
      </ul>
    </div>
    <div class="form-group row">
    <label  class="col-sm-3 col-form-label">Email<span v-show="isEmailValid" class="  text-danger">*</span></label>
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
  </section>
</template>

<script>

import services from "../shared/services";

export default {
  
  name: "loginForm",
  data() {
    return {
      
      email: null,
      password: null,
              
      isPasswordValid: false,
      isEmailvalid: false,
      isPasswordVerified: false,
      isEmailVerified: false,
      isPasswordRules:false,
      msg: ["",""],
      passwordRules:[{message:"Password must have 6 length of character"},
                     {message:"Password must have atleast one upper case letter"},
                     {message:"Password must have atleast one lower case letter"}
                    ],
      changePage:null,
             
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
      isEmailValid: function (email) {
          var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
          return re.test(email);}
      ,
      isPasswordCorrect(password){
        var strongRegex = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})");
        return strongRegex.test(password);
      },
      VerifyInput(){
            if(!this.isPasswordValid && !this.isEmailvalid &&  this.isPasswordVerified && this.isEmailVerified )
            {
              if(this.isPasswordCorrect(this.password))
              {
                   this.isPasswordRules = false;
                   alert(this.save());
              }
              else
              {
                this.isPasswordRules = true;
              }
             
            }
            else{
              alert("here")
               this.isPasswordValid = true;
               this.isEmailvalid = true
            }
        },

        async save() {
            const userdate ={
              email: this.email,
              password: this.password
            }
            try { 
                this.changePage = await services.postApplication(userdate);
            }
            catch(error) {
               alert(error, "Failed to save application", error);
            }
        }
        
        },
        watch: {
          email(){
            
            if(!this.email)
            {
              this.isEmailvalid = false;
              this.isEmailVerified=false;
              this.msg[0] = "Email is requred"
            }
             else if(!this.isEmailValid(this.email))
            {
                  this.isEmailVerified=true;
                    this.isEmailvalid = true;
                  this.msg[0] = "Enter valid Email"
            }
            else 
            { this.isEmailvalid = false;
              this.isEmailVerified=true;}
          },
          password(){
            if(!this.password)
            {
              this.isPasswordValid = true;
              this.msg[1] = "Password is requred";
              this.isPasswordVerified = false
            }
            else if(this.password.length < 6)
            {
              this.msg[1] = "Password must have at least 6 character";
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