<template>
  <div>
   

    <b-modal v-model="isShow" :title="title" >{{msg}}</b-modal>
       
  </div>
</template>

<script>

export default {
    name:"message",
    
    data() {
        return{
            title:null,
            msg:null,
            isShow:null
            };
    },
    methods:{
        showModal(title,message){
            this.title = title,
            this.msg = message,
            this.isShow = true
        },
        hideModal() {
              this.isShow = false
        }
    }
}

</script>

<style>

</style>