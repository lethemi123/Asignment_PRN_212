   M S B A M L   `   `   `  ����@  <Test1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Test1.UserControlBarTest1.UserControlBar  5          Test1.UpdateProfile   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Test1.UserControlBar     5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      -   5          � Title$  UpdateProfile��5	      $	��800��5
      $	��450��5       � 
ResizeMode$ NoResize=�5       � WindowStyle$
 None=�5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��0.2* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $
��0.2* �6   �� 5      $
��0.1* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��0.5* �6   �� 5      $
��0.7* �6   �� 5      $
��0.7* �6   �� 5      $��20 �6   .+�5!   
   � $��0��6   $��7��6   .+�5"      '   !Test1.UserControlBar.ControlBarUC  5#      ]� 5$   
   $��1��5%      $��2��5&      $��2��5'      .+�5(      �� $��Center=�5)      $��Center=�5*      $��Segoe UI Black)�5+      $��25(�5,      $
��Bold"�5-         PrimaryHueMidBrush#���   5.      $��Your information��5/      50      � 54   
   $��2��55      $��2��56      $��2��57      $��2��58      $��Center=�59      .+�5;      � $	��505��5<      $��0,0,0,20q�5=      $��Center=�5>       5?      �� 5@      $��1* �6'   �� 5A      $��10 �6'   �� 5B      $��1* �6'   .+�5F      �� -   5         ��Name$ txtFirstName��5G      $��3��5H      $��0��5I      $��10q�5J      $	��Top=�5K      )  #MaterialDesignThemes.Wpf.HintAssist   
Background
 �����   
HelperText$  ��5M         HelperTextFontSize$ 12Q�5N      	   Hint$	 
First Name��5O      
   HintPaddingBrush

 ����� ! MaterialDesignOutlinedTextBox#��[ 5Q       �� TextWrapping$
 Wrap=�5R      " �� VerticalScrollBarVisibility$
 Auto=�5S      �� 5U      -   5        $ txtLastName��5V      $��3��5W      $��2��5X      $��10q�5Y      $	��Top=�5Z      
 �����$  ��5\      $ 12Q�5]      $	 	Last Name��5^      

 �����#��[ 5`      $
 Wrap=�5a      $
 Auto=�5b      5c      � 5f      $	��505��5g      $��0,0,0,10q�5h      $��Center=�5i       5j      �� 5k      $��* �6'   �� 5l      $��10 �6'   �� 5m      $��* �6'   .+�5o      �� -   5        $ txtPhoneUser��5p      $��0��5q      $��10q�5r      $	��Top=�5s      
 �����$  ��5u      $ 12Q�5v      $	 Phone Number��5w      

 �����#��[ 5y      $
 Wrap=�5z      $
 Auto=�5{      �� 5}      $��2��5~      $��	20,0,00,0q�5      $
��Left=�5�      $��Center=�5�       �� Orientation$ 
Horizontal=�5�      .+�5�      	� -   5         	�Name$ rdoMale��5�      $��0,0,20,0q�5�      $
��Male��5�      $��14(�5�       	� 	GroupName$ Gender��5�      	� 5�      -   5        $ 	rdoFeMale��5�      $��0,0,20,0q�5�      $��Female��5�      $��14(�5�      $ Gender��5�      	� 5�      -   5        $ rdoOther��5�      $��Other��5�      $��14(�5�      $ Gender��5�      5�      5�      � 5�      $	��505��6   $��	0,10,0,20q�6    5�      �� 5�      $��247.5 �6'   �� 5�      $��10 �6'   �� 5�      .+�5�      �� -   5        $ 
txtAddress��5�      $��0��5�      $��10q�5�      $	��Top=�5�      
 �����$  ��5�      $ 12Q�5�      $	 Address��5�      

 �����#��[ 5�      $
 Wrap=�5�      $
 Auto=�5�      (  "System.Windows.Controls.DatePicker  5�      $��2��5�      $	��140��5�      $��10q�5�      $
��Left=�5�      
 �����$	 Your BirthDay��5�      

 ����� $  MaterialDesignOutlinedDatePicker#��[ 5�      5�      �� 5�      $	��505��6   $ Vertical=�6%   .+�5�      �� $ 
Horizontal=�6   .+�5�      �� -	   5         ��Name$# FilledComboBoxEnabledCheckBox��5�       J� RenderTransformOrigin$ 0.561,0.723&�6F   �� 5�      $��10,0,0,0q�5�      $��Center=�5�      $)��#I agree to the terms and conditions��5�      5�      �� 5�      -
   5         ��Name$ btnLogin��5�      $	��150��5�      $��	0,20,20,0q�5�       % !MaterialDesign.Brush.Primary.Dark#��[ 5�      $��Submit��5�      $
��Bold"�5�      {�5�      �� *	IsChecked+ �� ElementName$# FilledComboBoxEnabledCheckBox��5�      5�      5�      5�      