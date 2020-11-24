<template>
    <div class="barraTop">
        <nav >
            <router-link to="/Professores">Professores</router-link>
            <router-link to="/todosAlunos">Alunos</router-link>
            <router-link to="/Sobre">Sobre</router-link>
        </nav>
    </div>
</template>

<script>
    export default {
        
    }
</script>

<style scoped>
.barraTop{
    background-color: rgb(230,230, 230)   
}

nav{
     padding: 20px 20px 20px 0;
}
nav a{
    padding: 10px;
    text-decoration: none;
    background-color: white;
    border-radius: 3px;
    color: rgb(0, 110, 255);
    font-weight: bold;
    margin-right: 15px;
}
nav .router-link-active{
    background-color: #707070;
    color: white;
}


</style>