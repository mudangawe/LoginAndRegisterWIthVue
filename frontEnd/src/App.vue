<template>
  <div id="app" data-grid="container">
    <div id="loginPage" v-if="isLogin">
      <heading></heading>
      <loginForm @submit="changeForm"></loginForm>
    </div>
    <div id="registerPage" v-else>
      <heading ></heading>
      <register></register>
    </div>
    <footerhere></footerhere>
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
      isLogin: true,
      info: null
    };
  },
   methods: {
    
    changeForm(value){
      if(value)
      {
        this.isLogin =false
      }
    }
  }
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
