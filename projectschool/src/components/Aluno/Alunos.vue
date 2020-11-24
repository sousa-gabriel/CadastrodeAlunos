<template>
  <div >
    <Titulo :texto=" professorid !== undefined ? 'Professor: ' + professor.nome :'Todos os Alunos' "/>
    <div v-if="professorid !== undefined">
      <input 
        type="text" 
        placeholder="Nome do Aluno"
        v-model ="nome"
        v-on:keyup.enter="AddAluno()"
      >
      <button class='btnAdicionar' @click="AddAluno()">Adicionar</button>
    </div>
    <table >
      <thead>
        <th>Matricula</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <td>{{aluno.id}}</td>
          <router-link 
            tag="td"
            :to="`/alunoDetalhe/${aluno.id}`"
            style="cursor:pointer"
            >
            {{aluno.nome}}  {{aluno.sobrenome}}
          </router-link>
          <td>
            <button class='btn' @click="remover(aluno)"> Remover Aluno </button>
          </td>
        </tr>
      </tbody>
      <tfoot  v-else >
        Nenhum Aluno Encontrado
      </tfoot>
    </table>
  </div>

</template>

<script>
import Titulo from '../_share/Titulo'

export default {
  components:{
    Titulo
  },
  data(){
    return {
      titulo:'Aluno',
      professorid: this.$route.params.prof_id,
      nome:'',
      alunos:[],
      professor: [],
    };
  },
  created() {
    if(this.professorid){
      this.carregarProfessores();
      this.$http
      .get('http://localhost:3000/alunos?professor.id=' + this.professorid)
      .then(res => res.json())
      .then(alunos => this.alunos = alunos)

    }else{
      this.$http
      .get('http://localhost:3000/alunos')
      .then(res => res.json())
      .then(alunos => this.alunos = alunos)
    }
  },
  props: {
  },
  methods: {
    AddAluno() {
      let _aluno ={
        nome: this.nome,
        sobrenome:'',
        professor:{
          id: this.professor.id,
          nome: this.professor.nome,
        }
      }

      this.$http
      .post('http://localhost:3000/alunos', _aluno)
      .then(res => res.json())
      .then(alunoRetornado => {
        this.alunos.push(alunoRetornado)
        this.nome ='';
      })
    },
    remover(aluno){
      this.$http
      .delete(`http://localhost:3000/alunos/${aluno.id}`)
      .then(() => {
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice,1)
      })
    },
    carregarProfessores(){
    this.$http
      .get('http://localhost:3000/professores/' + this.professorid)
      .then(res => res.json())
      .then(professor => {
        this.professor = professor;
      })
    }
  },
}
</script>

<style scoped>
  input{
    width: 60%;
    padding: 5px;
  }
  .btnAdicionar{
    background-color: chartreuse;
    width: 35%;
    padding: 5px;
    color: white;
    font-weight: bold;
    cursor: pointer;
    border-radius: 5px;
  }
</style>
