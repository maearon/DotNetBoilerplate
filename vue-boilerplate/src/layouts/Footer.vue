<template>
  <v-footer app class="mt-5">
    <v-container>
      <div class="d-flex flex-column align-center">
        <div>
          <router-link to="/about">About</router-link>
          <router-link to="/contact" class="ml-2">Contact</router-link>
          <a href="https://vuejs.org/" target="_blank" rel="noopener noreferrer" class="ml-2">News</a>
        </div>
        <div class="mt-2">
          <a href="https://vuejs.org/" target="_blank" rel="noopener noreferrer">
            <v-img src="/vue.svg" alt="Vue.js logo" width="100" height="30" />
          </a>
        </div>
      </div>
    </v-container>
  </v-footer>
</template>
