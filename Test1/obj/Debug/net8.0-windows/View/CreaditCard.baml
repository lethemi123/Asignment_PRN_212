   M S B A M L   `   `   `  ����@  <Test1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Test1.UserControlBarTest1.UserControlBar  5          Test1.View.CreaditCard   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Test1.UserControlBar     5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      -   5        $	��300��5	      $	��450��5
        � 
ResizeMode$  NoResize=�5       � WindowStyle$
 None=�5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   � $��0��6   $��7��6   .+�5      '   !Test1.UserControlBar.ControlBarUC  5      �� 5   
   $��1��5      $��1��5       $��Center=�5!      $��Center=�5"      $@��:C:\Users\lethe\source\repos\Test1\Test1\Image\QRCredit.jpg��5#      �� 5$   
   $��2��5%      $��1��5&       �� Orientation$ Vertical=�5'      .+�5(      �� $��0 10 0 0q�6   $ 
Horizontal=�6,   .+�5)      �� $��70��5*      $
��Left=�5+      $��16(�5,      $
��Bold"�5-      $��Name: ��5.      �� 5/      $��80��50      $
��Left=�51      $��16(�52      $
��Bold"�53      $��	LE THE MY��54      55      �� 56      $��0 10 0 0q�6   $ 
Horizontal=�6,   .+�57      �� $��70��58      $
��Left=�59      $��16(�5:      $
��Bold"�5;      $��Bank: ��5<      �� 5=      $
��Left=�5>      $��16(�5?      $
��Bold"�5@      $��Techcombank��5A      5B      �� 5C      $��0 10 0 0q�6   $ 
Horizontal=�6,   .+�5D      �� $��70��5E      $
��Left=�5F      $��16(�5G      $
��Bold"�5H      $��STK: ��5I      �� 5J      $��70��5K      $
��Left=�5L      $��16(�5M      $
��Bold"�5N      $��LYM123 ��5O      5P      �� 5Q      $��0 10 0 0q�6   $ 
Horizontal=�6+   .+�5R      �� $��70��5S      $
��Left=�5T      $��16(�5U      $��Center=�5V      $
��Bold"�5W      $
��MSSV��5X      �� 5Y      -   5         ��Name$ txtInputMSSV��5Z      $��5q�5[      $	��Top=�5\      )  #MaterialDesignThemes.Wpf.HintAssist   
Background
 �����$	��120��5^         HintPaddingBrush
 ����� !  MaterialDesignOutlinedTextBox#��[  5a       �� TextWrapping$
 Wrap=�5b      "	 �� VerticalScrollBarVisibility$
	 Auto=�5c      5d      �� 5e      $��0 20 0 0q�6   $��Bottom=�6+   $��Center=�6F   $ 
Horizontal=�6c   .+�5f      �� -   5        
 ��Name$
 btnSaveCreadit��5f      $��80��61   $��0 0 20 0q�6<     ColorSubmit#��[ 6N   $
��Done��6y   $
��Bold"�6�   6�   �� 5g      -   5        $
 btnExit��5g      $��80��6*     ColorRedsolid#��[ 65   $
��exit��6a   $
��Bold"�6p   6�   5h      5j      5l      5m      