<template>
  <div>
    <Titulo texto="Professores" />
    <table>
      <thead>
        <th>Código</th>
        <th>Nome</th>
        <th>Alunos</th>
      </thead>
      <tbody v-if="professores.length">
        <tr v-for="(professor, index) in professores" :key="index">
          <td>{{ professor.id }}</td>
          <router-link 
            :to="`/Alunos/${professor.id}`" 
            tag="td" 
            style="cursor:pointer"
          >
            {{ professor.nome }} {{ professor.sobrenome }}
          </router-link>
          <td>
            {{professor.quantidadeAlunos}}
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        Nenhum professor Encontrado
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo";
export default {
  components: {
    Titulo,
  },
  data() {
    return {
      professores: [],
      alunos:[],
    };
  },
  created() {
      this.$http
      .get('http://localhost:3000/alunos')
      .then(res => res.json())
      .then(alunos => {
        this.alunos = alunos;
        this.carregarProfessores();
      })
  },
  props: {
  },
  methods: {
    AlunosPorProfessor(){
      this.professores.forEach((professor, index) => {
        professor = {
          id: professor.id,
          nome: professor.nome,
          quantidadeAlunos: this.alunos.filter(aluno =>
            aluno.professor.id === professor.id
          ).length
        }
        this.professores[index] = professor; 
      });
    },
    carregarProfessores(){
    this.$http
      .get('http://localhost:3000/professores')
      .then(res => res.json())
      .then(professor => {
        this.professores = professor;
        this.AlunosPorProfessor();
      })
    }
  },
};
</script>

<style scoped></style>
