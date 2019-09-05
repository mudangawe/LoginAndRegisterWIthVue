<template>
  <section aria-label="Form">
    
    <div>
     <label class="row">
        Email
        <span class="text-danger">*</span>
      </label>
      <div class="row">
      <input id="default" required type="text" name="Email" v-model="profile.email" />
      </div>
       <div class="row">
      <span v-if="isEmailvalid" class="text-danger">{{msg[0]}}</span>
      </div>
    </div>
    <div>
      <label class="row">
        Password
        <span class="text-danger">*</span>
      </label>
      <div class="row">
      <input id="default" type="password" name="password" v-model="profile.password"  />
     
    </div>
    <div class="row">
       <span v-if="isPasswordValid" class="text-danger"> 
          {{msg[1]}}
         </span>
    </div>
    </div>
    <div v-if="isPasswordRules">
       <ul id="passwordrules">
          <li v-for="item in passwordRules" v-bind:key="item.id">
          {{ item.message }}
        </li>
      </ul>
    </div>
    <div class="row">
      <input type="Submit" text="Submit" @click="VerifyInput" />
    </div>
  </section>
</template>

<script>
//import axios from "axios";
import services from "../shared/services";
export default {
  
  name: "loginForm",
  data() {
    return {
      profile: {
        email: null,
        password: null
              },
      isPasswordValid: false,
      isEmailvalid: false,
      isPasswordRules:false,
      msg: ["",""],
      passwordRules:[{message:"Password must have 8 length of character"},
                     {message:"Password must have atleast one upper case letter"},
                     {message:"Password must have atleast one lower case letter"}
                    ],
      changePage:null        
    }
  },
 computed: {
    VerifyInput(){
            if(!this.profile.email)
            {
              this.isEmailvalid = true;
              this.msg[0] = "Email is requred"
            }
             else if(!this.validEmail(this.profile.email))
            {
                  this.msg[0] = "Enter valid Email"
            }
            else 
            { this.isEmailvalid = false;}
            if(!this.profile.password)
            {
              this.isPasswordValid = true;
              this.msg[1] = "Password is requred"
            }
            else if(!this.profile.password.length > 6)
            {
              this.msg[1] = "Password must have at least 6 character"
              this.isPasswordValid = true;
            }
            else { this.isPasswordValid = false;}

            if(this.isPasswordValid == false && this.isEmailvalid == false)
            {
              console.log(true);
              this.save();
            }
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
      validEmail: function (email) {
          var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
          return re.test(email);}
      ,
      
      VerifyInput(){
            if(!this.profile.email)
            {
              this.isEmailvalid = true;
              this.msg[0] = "Email is requred"
            }
             else if(!this.validEmail(this.profile.email))
            {
                  this.msg[0] = "Enter valid Email"
            }
            else 
            { this.isEmailvalid = false;}
            if(!this.profile.password)
            {
              this.isPasswordValid = true;
              this.msg[1] = "Password is requred"
            }
            else if(!this.profile.password.length > 6)
            {
              this.msg[1] = "Password must have at least 6 character"
              this.isPasswordValid = true;
            }
            else { this.isPasswordValid = false;}

            if(this.isPasswordValid == false && this.isEmailvalid == false)
            {
              console.log(true);
              this.save();
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
        watch: {
          changePage(){
                this.respondToUser();
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