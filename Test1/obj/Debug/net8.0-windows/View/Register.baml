   M S B A M L   `   `   `  ����@  <Test1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Test1.UserControlBarTest1.UserControlBar  5          Test1.Register   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Test1.UserControlBar     5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      -   5        $	��800��5	      $	��450��5
        � 
ResizeMode$  NoResize=�5       � WindowStyle$
 None=�5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $��* �6   �� 5      $
��0.1* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��0.7* �6   �� 5      $
��0.7* �6   �� 5      $
��0.7* �6   �� 5      $��20 �6   .+�5   
   � $��0��6   $��7��6   .+�5       '   !Test1.UserControlBar.ControlBarUC  5!      �� 5"   
   $��1��5#      $��3��5$      $��2��5%      $��0,30,0,0q�5&      $��Center=�5'      $��Segoe UI Black)�5(      $��25(�5)      $
��Bold"�5*         PrimaryHueMidBrush#���   5+      $��Creat New Account��5,      �� 5-   
   $��1��5.      $��3��5/      $��1��50      $��2��51      $?��9C:\Users\lethe\source\repos\Test1\Test1\Image\sign-up.png��52      �� 53   
   $��1��54      $��4��55      $��2��56      $��4��57      $��125,131,25,0q�58       �� Orientation$ Vertical=�59      .+�5:      �� $��16(�6   �� 5;      $�Already have an account? ��6    �� 5<      -   5        .�5<   4   .�5=      �� $�
Login here��6   5>      5?      � 5A      $��0,20,0,0q�6    5B      �� 5C      $��* �6'   �� 5D      $��2* �6'   .+�5F      �� $
��Left=�5G      $��Center=�5H      $��16(�5I      #���   5J      $��Name: ��5K      �� 5L      -   5         ��Name$ txtUserName��5M      $��1��5N      $	��190��5O      $��10q�5P      $��Center=�5Q      )  #MaterialDesignThemes.Wpf.HintAssist   
Background
 �����   Hint$ Enter Your Name��5S         HintPaddingBrush
 ����� ! MaterialDesignOutlinedTextBox#��[ 5U      	 �� TextWrapping$
	 Wrap=�5W      "
 �� VerticalScrollBarVisibility$

 Auto=�5X      5Y      � 5[      $��0,20,0,0q�6    5\      �� 5]      $��* �6'   �� 5^      $��2* �6'   .+�5`      �� $
��Left=�5a      $��Center=�5b      $��16(�5c      #���   5d      $��
Password: ��5e      G� 5f      -   5         G�Name$ txtPassword��5g      $��1��5h      $	��190��5i      $��10q�5j      $��Center=�5k      
 �����   
HelperText$  ��5m         HelperTextFontSize$ 10Q�5n        HelperTextStyleOverride   HelperTextStyle# [ 5o      $ Password��5p      
 �����.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��5r       + 'MaterialDesignOutlinedRevealPasswordBox#��[ 5t      5u      � 5w      $��0,20,0,0q�6    5x      �� 5y      $��* �6'   �� 5z      $��2* �6'   .+�5|      �� $
��Left=�5}      $��Center=�5~      $��16(�5      #���   5�      $��Email: ��5�      �� 5�      -   5        $ txtEmail��5�      $��2��5�      $	��190��5�      $��10q�5�      $��Center=�5�      
 �����$  ��5�      $ Enter Your Email��5�      
 �����#��[ 5�      $
	 Wrap=�5�      $

 Auto=�5�      5�      �� 5�      -   5         ��Name$ btnCreateAccount��5�      $��0,20,0,0q�5�      $��Creat Account��5�      $
��Bold"�5�      5�      5�      5�      