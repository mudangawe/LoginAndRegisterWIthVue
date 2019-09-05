<template>
  <div id="app" data-grid="container">
    <heading v-bind:title="titlehead"></heading>
    <div id="loginPage" v-if="isLoginPage"> 
      <loginForm ></loginForm>
    </div>
    <div id="registerPage" v-else>
      <register></register>
    </div>
    <footerhere @submit="changeForm" ></footerhere>
  </div>
</template>

<script>
import heading from "./components/heading";
import footerhere from "./components/footer";
import loginForm from "./components/form";
import register from "./components/register";
export default {
  name: "app",
  components: {
    heading,
    footerhere,
    loginForm,
    register
  },
  data() {
    return {
      isLoginPage: true,
      info: null,
      titlehead: "Login page"
    };
  },
   methods: {
    
    changeForm(value){
      
      if(!value &&   this.isLoginPage==true)
      {
        this.isLoginPage = false;
        this.titlehead = "Register Page"
      }
      else{
        this.isLoginPage = true;
        this.titlehead = "Login page"
      }
    }
  },
 
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  margin-top: 20px;
}
#topContent {
  height: 100%;
  background-color: #e3f2fd;
  min-height: 100%;
  height: auto !important;
  margin-bottom: -50px;
}
</style>
