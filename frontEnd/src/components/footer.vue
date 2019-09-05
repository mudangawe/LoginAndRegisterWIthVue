<template>
 <!-- Footer -->
<footer class="page-footer font-small teal pt-4">

  <!-- Footer Text -->
  <div class="container-fluid text-center text-md-left">

    <!-- Grid row -->
    <div class="row">

      <!-- Grid column -->
      <div class="col-md-6 mt-md-0 mt-3">

        <!-- Content -->
        <h5 class="text-uppercase font-weight-bold">Vue.js with HTML</h5>
        <p>This is created using vue technology with HTML,Bootstrap and javascript.</p>

      </div>
      <!-- Grid column -->

      <hr class="clearfix w-100 d-md-none pb-3">

      <!-- Grid column -->
      <div class="col-md-6 mb-md-0 mb-3">

        <!-- Content -->
        <h5 class="text-uppercase font-weight-bold">ASP.NET</h5>
        <p>This page has backend page asp backend page that communicate with front end 
          using API. It also have a database that hold information of user.
        </p>

      </div>
    </div>
  </div>
  <div>
  <ul class="list-unstyled list-inline text-center py-2">
      <li class="list-inline-item">
        <h5 class="mb-1">{{msg}}</h5>
      </li>
      <li class="list-inline-item">
        <a @click="gotoRegister" href="#!"  class="btn btn-outline-white btn-rounded">{{butonTitle}}</a>
      </li>
    </ul>
    <!-- Call to action -->

  </div>
  <div class="footer-copyright text-center py-3">© 2019 Ndivhuwo Gift:
    <a> Facebook.com/page</a>
  </div>
  <!-- Copyright -->

</footer>
<!-- Footer -->
</template>

<script>
export default {
name:"footer-here",

data() {
  return {
      isPressed: false,
      msg:"Register for free",
      butonTitle:"Sign up!"
  }
},

methods:{
  gotoRegister(){
    this.$emit("submit", false);
  }
}

}
</script>

<style>
     
</style>