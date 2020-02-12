<template>
   <section aria-label="Form">
              <div>
                  <div class="form-group row">
                     <label class="col-sm-3 col-form-label">Name<span v-show="error[0]" class="text-danger">*</span></label>
                      <div class="col-sm-8">
                      <input v-model="profile.Name"  class="form-control"  />
                       </div>
                      
                  </div>
                  <div class="form-group row">
                      <label class="col-sm-3 col-form-label">Surname <span v-show="error[1]" class="text-danger">*</span> </label>
                      <div class="col-sm-8">
                      <input  class="form-control" v-model="profile.Surname" />
                      </div>
                     
                  </div>
                  <div class="form-group row" >
                      <label class="col-sm-3 col-form-label">Email<span v-show="error[2]" class="text-danger">*</span> </label>
                       <div class="col-sm-8">
                      <input  v-model="profile.Email" class="form-control"/>
                      </div>
                      
                      
                  </div>
                  <div class="form-group row">
                      <label class="col-sm-3 col-form-label">Contact<span v-show="error[3]" class="text-danger">*</span> </label>
                       <div class="col-sm-8">
                         <input  v-model="profile.Contact"  class="form-control" maxlength="10"/>
                      </div>
                     
                  </div>
                  <div class="form-group row">
                      <label class="col-sm-3 col-form-label" >Address<span v-show="error[4]" class="text-danger">*</span> </label>
                       <div class="col-sm-8">
                      <input  v-model="profile.Address"  class="form-control" />
                      </div>
                    
                  </div>
                  <div class="form-group row">
                      <label class="col-sm-3 col-form-label">Password <span v-show="error[5]" class="text-danger">*</span> </label>
                      <div class="col-sm-8">
                      <input  class="form-control"   type="password" v-model="profile.Password"/>
                      </div>
                      
                  </div>
                  <div class="form-group row" >
                      <label class="col-sm-3 col-form-label" >Confirm Password <span v-show="error[6]" class="text-danger">*</span></label>
                      <div class="col-sm-8">
                      <input v-model="profile.ConfirmPassword"  type="password"  class = "form-control" />
                      </div>
                  </div>
              </div>
             <div class="form-group row">
                <div class="col-sm-10">
                <input  type="submit" value="Submit" @click="save()" :disabled="isDisable" />
              </div>
              </div>
         <message ref="child"></message>
      </section>
</template>



<script>
import services from "../shared/services";
import message from "./dialogs/message";
export default {
    name:"register",
    components:{
        message
    },
    data(){
        return{
            isDisable:true,
            profile:{
                Name:null,
                Surname:null,
                Email:null,
                Contact:null,
                Address:null,
                Password:null,
                ConfirmPassword:null
            },
            error:[false,false,false,false,false,false,false],
            qualityInput:[true,true,true,true,false,true,true],
        }
    },
    computed:{
            
    },
    methods:{
        isDisableValid(){
                let value = this.error.every(this.isAllVerified);
                let values = this.qualityInput.every(this.isAllVerified);
                if(!values)
                {
                    return (this.isDisable =true)
                }
                if(!value)
                {
                    return (this.isDisable =true)
                }
                this.isDisable = value && !values;
               return(this.isDisable)
               
            },
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
        
        
        async save() {
            
            try { 
               this.userData = await services.postApplication(this.profile);
               this.$refs.child.showModal("Feedback", String(this.userData.message));
            }
            catch(error) {
               alert(error, "System failure", error);
            }
        }
    },
    watch:{
        'profile.Name'(){
             this.isDisableValid();
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
            this.isDisableValid();
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
                 this.isDisableValid();
                if(!this.profile.Email)
                {
                    this.error[2] = true;
                   
                    this.qualityInput[2] = true;
                }
                else
                {
                    if(this.isEmailvalid())
                    {
                      this.error[2] = false;
                      this.qualityInput[2] = false;
                      this.isDisableValid();
                    }
                    else
                    {
                       
                        this.error[2] = true;
                        this.qualityInput[2] = true;
                    }
                }
            },
            'profile.Contact'(){ 
                
                if(this.profile.Contact == null)
                {
                    this.error[3] = true;
                  
                }
                else
                {
                    if(this.isNumberValid())
                    {
                         this.error[3] = false;
                         this.qualityInput[3] = false;
                         this.isDisableValid();
                    }
                    else
                    {
                         this.isDisableValid();
                        this.error[3] = true;
                        this.qualityInput[3] = true;
                        
                    }
               }
            
            },
            'profile.Password'(){
               
             if(!this.profile.Password)
             {
              
                this.error[5] = true;  
                this.qualityInput[5] = true;              
             }
             else
             {
                 if(this.isPasswordCorrect(this.profile.Password))
                 {
                    this.error[5] = false;  
                    this.qualityInput[5] = false;  
                     this.isDisableValid(); 
                 }
                 else
                 {
                   
                    this.qualityInput[5] = true;  
                    this.error[5] = true;
                 }
             }
            },
            'profile.ConfirmPassword'(){
            //this.isDisable()();
            if(!this.profile.ConfirmPassword)
             {
               
                this.error[6] = true;  
                this.qualityInput[6] = true;              
             }
             else{
                 if(this.profile.ConfirmPassword == this.profile.Password)
                 {
                      this.qualityInput[6] = false;
                      this.error[6] = false; 
                      this.isDisableValid();
                 }
                 else
                 {
                       this.qualityInput[6] = true;
                      
                 }
             }
            }
            
            
        },
        
       
    }

</script>

<style>


  
</style>