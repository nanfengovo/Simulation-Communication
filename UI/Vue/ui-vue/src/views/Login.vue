<template>
  <div class="login">
    <div class="login-container">
      <div class="login-header">
        <h2>用户登录</h2>
      </div>
      <el-form class="login-form" :model="loginForm" size="large">
        <el-form-item>
          <el-input v-model="loginForm.username" placeholder="请输入用户名" prefix-icon="User" @keyup.enter="handleLogin" />
        </el-form-item>
        <el-form-item>
          <el-input v-model="loginForm.password" type="password" placeholder="请输入密码" prefix-icon="Lock" show-password
            @keyup.enter="handleLogin" />
        </el-form-item>
        <el-form-item>
          <div class="remember-me">
            <el-checkbox v-model="loginForm.remember">记住我</el-checkbox>
          </div>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" class="login-button" @click="handleLogin" :loading="loading">登录</el-button>
        </el-form-item>
      </el-form>
    </div>
  </div>
</template>

<script setup lang="ts">
import { reactive, ref, onMounted } from 'vue'
import { ElMessage } from 'element-plus'
import { User, Lock } from '@element-plus/icons-vue'
import { useRouter } from 'vue-router'
import axios from 'axios'

const loginForm = reactive({
  username: '',
  password: '',
  remember: localStorage.getItem('remember') === 'true'
})

const loading = ref(false)
const router = useRouter()

// 组件挂载时加载保存的用户名
onMounted(() => {
  const savedUsername = localStorage.getItem('username')
  if (savedUsername) {
    loginForm.username = savedUsername
    loginForm.remember = true
  }
})

const handleLogin = async () => {
  if (!loginForm.username) {
    ElMessage.warning('请输入用户名')
    return
  }
  if (!loginForm.password) {
    ElMessage.warning('请输入密码')
    return
  }

  loading.value = true

  try {
    const response = await axios({
      url: 'http://localhost:5049/api/Authorize/Login',
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      data: {
        userName: loginForm.username,
        userPwd: loginForm.password
      }
    })

    // axios 直接返回响应数据，不需要检查 response.ok
    const data = response.data

    // 如果需要，可以保存token到localStorage
    if (data.data) {
      localStorage.setItem('token', data.data)
    }

    // 如果选择了记住我，可以保存用户名
    if (loginForm.remember) {
      localStorage.setItem('username', loginForm.username)
      localStorage.setItem('remember', 'true')
    } else {
      localStorage.removeItem('username')
      localStorage.removeItem('remember')
    }

    ElMessage.success('登录成功')
    console.log('登录信息:', data)

    // 登录成功后跳转到首页或其他页面
    // 由于路由配置中没有首页路由，暂时跳转到登录页面
    router.push('/')
  } catch (error) {
    console.error('登录错误:', error)
    ElMessage.error(error.message || '登录失败，请稍后重试')
  } finally {
    loading.value = false
  }
}

</script>

<style lang="less" scoped>
.login {
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  position: relative;
  overflow: hidden;

  &::before {
    content: "";
    position: absolute;
    top: -50px;
    left: -50px;
    right: -50px;
    bottom: -50px;
    background: url('data:image/svg+xml;utf8,<svg xmlns="http://www.w3.org/2000/svg" width="100" height="100" viewBox="0 0 100 100"><circle cx="50" cy="50" r="40" fill="rgba(255,255,255,0.1)"/></svg>');
    background-size: 100px 100px;
    opacity: 0.3;
    z-index: 0;
  }

  .login-container {
    width: 420px;
    background-color: rgba(255, 255, 255, 0.8);
    border-radius: 12px;
    box-shadow: 0 15px 35px rgba(0, 0, 0, 0.2);
    padding: 35px;
    backdrop-filter: blur(10px);
    -webkit-backdrop-filter: blur(10px);
    border: 1px solid rgba(255, 255, 255, 0.18);
    position: relative;
    z-index: 1;

    .login-header {
      text-align: center;
      margin-bottom: 35px;

      h2 {
        font-size: 28px;
        background: linear-gradient(to right, #667eea, #764ba2);
        -webkit-background-clip: text;
        -webkit-text-fill-color: transparent;
        font-weight: 600;
      }
    }

    .login-form {
      :deep(.el-form-item) {
        margin-bottom: 25px;
      }

      :deep(.el-input__wrapper) {
        box-shadow: 0 0 0 1px #ddd inset;
        padding: 0 15px;
        transition: all 0.3s;

        &.is-focus {
          box-shadow: 0 0 0 1px #667eea inset;
        }
      }

      :deep(.el-input__inner) {
        height: 45px;
      }

      .remember-me {
        display: flex;
        align-items: center;
        margin-top: -10px;
      }

      .login-button {
        width: 100%;
        height: 45px;
        font-size: 16px;
        font-weight: 500;
        background: linear-gradient(to right, #667eea, #764ba2);
        border: none;
        transition: all 0.3s;

        &:hover {
          opacity: 0.9;
          transform: translateY(-2px);
          box-shadow: 0 5px 15px rgba(102, 126, 234, 0.4);
        }
      }
    }
  }
}
</style>
