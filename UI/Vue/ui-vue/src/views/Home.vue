<template>
  <div class="home">

    <el-container class="main-container">
      <el-header class="header">Header</el-header>
      <el-container>
        <el-aside width="200px" class="aside">Aside</el-aside>
        <el-container>
          <el-main class="main">Main</el-main>
          <el-footer class="footer">Footer</el-footer>
        </el-container>
      </el-container>
    </el-container>

  </div>
</template>
<script setup lang="ts">
</script>

<style lang="less" scoped>
.home {

  width: 100vw;
}

.main-container {
  height: 100vh;
  width: 100vw;
}

.header {
  background-color: #B3C0D1;
  color: #333;
  text-align: center;
  line-height: 60px;
}

.aside {
  background-color: #D3DCE6;
  color: #333;
  text-align: center;
}

.main {
  background-color: #E9EEF3;
  color: #333;
  text-align: center;
}

.footer {
  background-color: #333;
  color: #fff;
  text-align: center;
}
</style>
