   M S B A M L   `   `   `  ����@  <Test1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Test1.UserControlBarTest1.UserControlBar  5          Test1.ForgotPassword   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Test1.UserControlBar     5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      -   5          � Title$  ForgotPassword��5	      $	��800��5      $	��450��5       � 
ResizeMode$ NoResize=�6    � WindowStyle$
 None=�5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $
��0.5* �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��0.7* �6   �� 5      $
��auto �6   �� 5      $��30 �6   �� 5      $��20 �6   �� 5       $
��auto �6   �� 5!      $
��0.7* �6   �� 5"      $��20 �6   .+�5$   
   � $��0��6   $��7��6   .+�5%      '   !Test1.UserControlBar.ControlBarUC  6#   5&      �� 5'   
   $��2��5(      $��4��5)      $��1��5*      $��2��5+      $D��>C:\Users\lethe\source\repos\Test1\Test1\Image\Daco_5735318.png��5,      �� 5-   
   $��2��5.      $��3��5/      $��4��50      $	��Top=�51      $
��Aria)�52      $��30(�53      $
��Bold"�54         PrimaryHueMidBrush#���   55      $��Forggot your password?��56      �� 57   
   $��2��58      $��3��59      $��4��5:      $��0,10,0,0q�5;      $��Center=�5<      $��13(�5=       % !MaterialDesign.Brush.Primary.Dark#���  5>      $5��/Please Enter your Email so we can send you otp ��5?      �� 5@   
   $��3��5A      $��3��5B      $��4��5C      $
��left=�5D       �� Orientation$ 
Horizontal=�5E      .+�5F      �� -   5         ��Name$ txtEmail��5G      $	��321��5H      $��10q�5I      $	��Top=�5J      )  #MaterialDesignThemes.Wpf.HintAssist   
Background
 �����   Hint$ Enter Email Adrress��5L      	   HintPaddingBrush
	 �����   MaterialDesign.Brush.Primary#���  5N       ! MaterialDesignOutlinedTextBox#��[ 5O      
 �� TextWrapping$

 Wrap=�5P      " �� VerticalScrollBarVisibility$
 Auto=�5Q      5R      �� 5S   
   -   5         ��Name$ btnCheckEmal��5T      $��4��5U      $��5��5V      $
��Bold"�6   $��3��5W      $��5��5X      $	��320��5Y      $��0,10,0,0q�5Z      $
��Left=�5[      $	��Top=�5\      $��Reset Password��5]      ���	#FF7535E65^   $   �� 5_   
   -   5        $��6��5`      $��3��5a      $��0,0,10,0q�5b      $��Right=�5c       � Cursor$
 Hand��5d      $��14(�5e      $
��Bold"�5f      $��Back to signin��5h      ��5i      �� 5j       �� 
TargetType" ��6   .�5k      ��  �� Property � �� �� Value
 �����63    �� Triggers 5l      P� 5m       P� Property �@J�IsMouseOver P� Value$
 True��69   . �5n      ��  � ��
 �����6;   5o      5q      5s      5t      5u      