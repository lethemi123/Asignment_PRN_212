   M S B A M L   `   `   `  ����@  <Test1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Test1.UserControlBarTest1.UserControlBar  5          Test1.Login   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Test1.UserControlBar     5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      -   5        $	��800��5	      $	��450��5
        � 
ResizeMode$  NoResize=�5       � WindowStyle$
 None=�5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $
��0.5* �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��2* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��25 �6   �� 5       $
��auto �6   �� 5!      $��* �6   �� 5"      $��20 �6   .+�5$   
   � $��0��6   $��7��6   .+�5%      '   !Test1.UserControlBar.ControlBarUC  6$   5&      �� 5'   
   $��1��5(      $��2��5)      $��3��5*      $	��100��5+      $��Center=�5,      $7��1E:\Asignment_PRN_212\Test1\Image\Daco_5096993.png��5-      �� 5.   
   $��3��5/      $��2��50      $��0,0,20,0q�51      $��Right=�52      $��Center=�53      $��14(�54      $
��Bold"�55      $��User Name: ��56      �� 57   
   -   5         ��Name$ txtUserName��58      $��3��59      $��3��5:      $��10q�5;      $	��Top=�5<      )  #MaterialDesignThemes.Wpf.HintAssist   
Background
 �����   Hint$ 
Enter Name��5>         HintPaddingBrush
 ����� !  MaterialDesignOutlinedTextBox#��[  5A       �� TextWrapping$
 Wrap=�5B      "	 �� VerticalScrollBarVisibility$
	 Auto=�5C      �� 5D   
   $��4��5E      $��2��5F      $��0,0,20,0q�5G      $��Center=�5H      $��Center=�5I      $��14(�5J      $
��bold"�5K      $��
Password: ��5L      �� 5M   
   $��4��6   $��3��6"   .+�5N      G� -   5        
 G�Name$
 txtPassword��5O      $��0,10,0,0q�5P      $��10q�5Q      $��Bottom=�5R      
 �����$ Password��5T      
 �����.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��5V       + 'MaterialDesignOutlinedRevealPasswordBox#��[ 5X      5Y      �� 5Z   
   -   5        $��5��5[      $��3��5\      $	��100��5]      $��0,5,0,0q�5^      $��Right=�5_      $	��Top=�5`       � Cursor$
 Hand��5a      $��forgot Password? ��5c       �� TextAlignment$ Right=�5d      ��5e      �� 5f       �� 
TargetType" ��6   .�5g      ��  �� Property � �� �� Value
 �����63    �� Triggers 5h      P� 5i       P� Property �@J�IsMouseOver P� Value$
 True��69   . �5j      ��  � ��
 �����6;   5k      5m      5o      �� 5p   
   $��6��5q      $��2��5r      $��3��5s      $��Center=�5t       �� Orientation$ 
Horizontal=�5u      .+�5v      �� -   5         ��Name$ btnLogin��5w      $	��150��5x      $��	0,10,20,0q�5y      ���	#FF7535E6$��Login��5|      $
��Bold"�5}      �� 5~      -   5        $ btnRegister��5      $	��150��5�      $��0,10,0,0q�5�      !  System.Windows.SystemColors   HighlightBrushKey#���  5�      $��SignUp��5�      $
��Bold"�5�      5�      5�      5�      