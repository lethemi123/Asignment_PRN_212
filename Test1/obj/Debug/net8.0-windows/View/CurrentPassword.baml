   M S B A M L   `   `   `  ����@  <Test1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Test1.UserControlBarTest1.UserControlBar  5          Test1.CurrentPassword   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Test1.UserControlBar     5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      -   5          � Title$  CurrentPassword��5	      $	��800��5
      $	��450��5       � 
ResizeMode$ NoResize=�5       � WindowStyle$
 None=�5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��0.4* �6   �� 5      $
��0.4* �6   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      $
��auto �6   �� 5"      $
��0.7* �6   �� 5#      $��20 �6   .+�5%   
   � $��0��6   $��7��6   .+�5&      '   !Test1.UserControlBar.ControlBarUC  5'      �� 5(   
   $��1��5)      $��2��5*      $��3��5+      $D��>C:\Users\lethe\source\repos\Test1\Test1\Image\Daco_4813615.png��5,      �� 5-   
   $��2��5.      $��2��5/      $��3��50      $��Center=�51      $��22(�52      $
��Bold"�53         PrimaryHueMidBrush#���   54      $��Set new password��55       �� TextAlignment$ Center=�56      �� 57   
   $��3��58      $��2��59      $��3��5:      $G��AYou new password must be different to 
 previously used passwords��5;      $ Center=�5<      �� 5=   
   $��4��5>      $��2��5?      $��3��5@      .+�5A      �� $��4��5B      $��2��5C      $��0,0,0,5q�5D      $��Center=�5E      $��10(�5F      $
��Bold"�5G      #���   5H      $��Password��5I      $
 Left=�5J      G� 5K      -   5         G�Name$ newPassword��5L      $��8q�5M      )  #MaterialDesignThemes.Wpf.HintAssist   
HelperText$  ��5N         HelperTextFontSize$ 10Q�5O        HelperTextStyleOverride	   HelperTextStyle#	 [ 5P      .  (MaterialDesignThemes.Wpf.TextFieldAssist
   HasClearButton$

 True��5Q      
����  � + 'MaterialDesignOutlinedRevealPasswordBox#��[ 5T      5U      �� 5V   
   $��5��5W      $��2��5X      $��3��5Y      $��0,20,0,0q�5Z      .+�5[      �� $��0,0,0,5q�5\      $��Center=�5]      $ 10Q�5^      $��10(�5_      $
��Bold"�5`      #���   5a      $��Confirm Password��5b      $
 Left=�5c      G� 5d      -   5        $ 
pwdConfirm��5e      $��8q�5f      $  ��5g      $ 10Q�5h      #	 [ 5i      $

 True��5j      
����  �#��[ 5m      5n      �� 5o   
   $��7��5p      $��2��5q      $��3��5r      $��0,10,0,0q�5s      $��Center=�5t      $	��Top=�5u       �� Orientation$ Vertical=�5v      .+�5w      �� -   5        $��0,20,0,0q�5x      ���	#FF7535E6$��Reset Password��5{      $
��Bold"�5|      5}      5~      5      