   M S B A M L   `   `   `  ����Y  USimulation Communication_WPFUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Simulation_Communication_WPFUI.Views$Simulation_Communication_WPFUI.Views  5      e7clr-namespace:Simulation_Communication_WPFUI.ViewModels)Simulation_Communication_WPFUI.ViewModels  5
      e7clr-namespace:Simulation_Communication_WPFUI.Extensions)Simulation_Communication_WPFUI.Extensions  5      2    ,Simulation_Communication_WPFUI.Views.LoginUC   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:Simulation_Communication_WPFUI.Views     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5	      H
viewmodels7clr-namespace:Simulation_Communication_WPFUI.ViewModels  5
      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 5      EpwdEx7clr-namespace:Simulation_Communication_WPFUI.Extensions  	 5      $	��450��5      $	��800��6   # 	 Prism.Services.Dialogs.Dialog    WindowStyle  5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property � �� �� Value$	 600��6&   �� 5       � ��$	 350��6'   �� 5       �@�SizeToContent$ WidthAndHeight=�6.   �� 5       �@�
ResizeMode$ NoResize=�6+   �� 5       �@ WindowStartupLocation$ CenterScreen=�6C   5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      .+�5   
   '  !MaterialDesignThemes.Wpf.Snackbar  -   5          Name$ RegLoginBar��5      $��2��6+      MessageQueue 6?   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  5       �� 5"   
   $��/Images/login.png��6   7  1MaterialDesignThemes.Wpf.Transitions.Transitioner  5$   
   $��1��6    �� SelectedIndex 6*   �� *SelectedIndex+ �� FallbackValue$ 0��.@�5&      <  6MaterialDesignThemes.Wpf.Transitions.TransitionerSlide  -   5        	  Name$	 Login��5&   #   .��5'      ]� $��15q�6   $��Center=�6(   .+�5(      �� $��欢迎使用��6    $
��Bold"�6,   $��22(�6>   $
��0,10q�6L   $	��Top=�6Z   6q   �� 5)      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 请输入账号��6   $	��Top=�69   $
��0,10q�6O   ��6]   �� *	Account+6y   G� 5+      $
 请输入密码��6"   $	��Top=�6=   $
��0,10q�6S   A   ;Simulation_Communication_WPFUI.Extensions.PasswordBoxExtend
   Pwd 6a   �� *Pwd+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�*  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 5,      C	   =Simulation_Communication_WPFUI.Extensions.PasswordBoxBehavior	  5-      5.      50      �� 51      $��登录��6   $
��0,10q�6*   $	��Top=�68   ��6M   �� *
LoginCmm+6l   ]� 53      $	��0 5q�6    $��False��6-   .+�54      �� $��注册账号��6$      Triggers 55      +
  %Microsoft.Xaml.Behaviors.EventTrigger
  56   "    
  	EventName$ MouseLeftButtonDown��61   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 57   &   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6<   �� *ShowRegInfoCmm+6a   58   #   5:      �� 5;      $��忘记密码��6$   $��Right=�60   6I   5<      5=      5?        5A      .��5B      ]� $��15q�6   $��Center=�6(   .+�5C      �� $��注册账号��6    $
��Bold"�6,   $��22(�6>   $
��0,10q�6L   $	��Top=�6Z   6q   �� 5D      $
 请输入姓名��6   $	��Top=�69   $
��0,10q�6O   ��6]   �� *AccountInfoDTO.Name+6�   �� 5E      $
 请输入账号��6   $	��Top=�69   $
��0,10q�6O   ��6]   �� *AccountInfoDTO.Account+6�   G� 5G      $
 请输入密码��6"   $	��Top=�6=   $
��0,10q�6S    6a   �� *AccountInfoDTO.Pwd+$ TwoWay=�$ PropertyChanged=� 5H      	  5I      5J      5L      G� 5M      $
 请再次输入密码��6"   $	��Top=�6?   $
��0,10q�6U    6c   �� *AccountInfoDTO.ConfrmPwd+$ TwoWay=�$ PropertyChanged=� 5N      	  5O      5P      5R      �� 5S      $��注册账号��6   $	��Top=�6,   ��6A   �� *Regcmm+6^   �� 5T      $��返回登录��6   $	��Top=�6,   $
��0 10q�6A       MaterialDesignOutlinedButton#��[  6O   ��6�   �� *ShowLogInfoCmm+6�   5U      5V      5W      5X      5Y      