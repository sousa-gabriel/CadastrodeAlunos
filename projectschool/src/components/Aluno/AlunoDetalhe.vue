<template>
    <div>
        <Titulo :texto="`Aluno: ${aluno.nome}`" />
        <button class="editar" @click="habilitarEditar()">Editar</button>
        <table>
        <tbody>
            <tr>
                <td class="colPequeno">Matricula</td>
                <td>
                    <label >{{aluno.id}}</label>
                </td>
            </tr>
            <tr>
                <td class="colPequeno">Nome:</td>
                <td>
                    <label v-if="this.editar === false" >{{aluno.nome}}</label>
                    <input
                        v-if="this.editar === true" 
                        v-model="aluno.nome" 
                        type="text"
                    />
                </td>
            </tr>
            <tr>
                <td class="colPequeno">Sobrenome:</td>
                <td>
                    <label v-if="this.editar === false" >{{aluno.sobrenome}}</label>
                    <input
                        v-if="this.editar === true" 
                        v-model="aluno.sobrenome" 
                        type="text"
                    />
                </td>
            </tr>
            <tr>
                <td class="colPequeno">Data Nascimento</td>
                <td>
                    <label v-if="this.editar === false" >{{aluno.dataNasc}}</label>
                    <input
                        v-if="this.editar === true" 
                        v-model="aluno.dataNasc" 
                        type="text"
                    />
                </td>
            </tr>
            <tr>
                <td class="colPequeno">Professor</td>
                <td>
                    <label >{{aluno.professor.nome}}</label>
                    <select
                        v-if="this.editar === true" 
                        v-model="aluno.professor"
                    >
                        <option 
                            v-for="(professor, index) in professores" 
                            :key="index"
                            v-bind:value="professor"
                        >
                        {{professor.nome}}
                        </option>
                    </select>
                </td>
            </tr>
        </tbody>
    </table>
    <div style="margint-top: 10px">
        <div  v-if="this.editar === true" >
            <button class="salvar" @click="Salvar()">Salvar</button>
            <button class="cancelar" @click="Cancelar()">Cancelar</button>
        </div>
    </div>
    </div>    
</template>

<script>
import Titulo from '../_share/Titulo'
    export default {
        components:{
            Titulo
        },
        data(){
            return{
                professores:[],
                editar: false,
                aluno:{},
                idAluno:this.$route.params.id
            }
        },
        created(){
            this.$http
                .get('http://localhost:3000/alunos/' + this.idAluno)
                .then(res => res.json())
                .then(aluno => this.aluno = aluno)

            this.$http
                .get('http://localhost:3000/professores')
                .then(res => res.json())
                .then(professor => this.professores = professor)
        },        
        methods: {
            habilitarEditar(){
                this.editar = !this.editar;
            },
            Salvar(){
                let _alunoEditar={
                    id: this.aluno.id,
                    nome: this.aluno.nome,
                    sobrenome: this.aluno.sobrenome,
                    dataNasc: this.aluno.dataNasc,
                    professor: this.aluno.professor
                }
                this.$http
                    .put('http://localhost:3000/alunos/'+ _alunoEditar.id, _alunoEditar);
                    this.Cancelar()
            },
            Cancelar(){
                this.editar = !this.editar;
            }
        },
        
    }
</script>

<style  scoped>
.colPequeno{
    width: 20%;
    text-align: right;
    font-weight: bold;
    background-color: rgb(255, 255, 255);
}
input, select{
    margin: 0px;
    padding: 5px 10px;
    font-size: 20px;
    border: 1px solid white;
    width: 95%;
    height: 50px;
}
select{
    width: 100%;
    height:40px ;
}
.editar{
    width: 100px;
    height: 40px;
    margin: 10px 0px;
    font-size: 20px;
    border-radius: 5px;
    background-color: teal;
    color: white;
}
.salvar{
    width: 100px;
    height: 40px;
    margin: 10px 0px;
    font-size: 20px;
    border-color: transparent;
    border-radius: 5px;
    background-color: rgb(49, 196, 68);
    color:black;
}
.cancelar{
    width: 100px;
    height: 40px;
    margin: 10px 10px;
    font-size: 20px;
    border-radius: 5px;
    border-color: transparent;
    background-color: rgb(269, 186, 92);
    color: black;
}
</style>