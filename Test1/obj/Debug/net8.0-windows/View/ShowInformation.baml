   M S B A M L   `   `   `  ����@  <Test1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Test1.UserControlBarTest1.UserControlBar  5           Test1.View.ShowInformation   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Test1.UserControlBar     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  ShowInformation��5       � WindowStyle$
 None=�5	      $	��300��5
      $	��500��5      
�������.��5      � .+�5   
   � $��0��6   $��7��6   .+�5      '   !Test1.UserControlBar.ControlBarUC  5      �� 5   
   $��Center=�5      $��Center=�5       �� Orientation$ Vertical=�5      .+�5      �� $��	0,30,0,20q�5      $��Center=�5      $��25(�5      $
��Bold"�5      $��Your Information��5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Bottom=�6   $��OrderId:��67   �� 5      -   5         ��Name$ 
txtOrderID��5       $	��100��5!      $��60,0,0,0q�5"       �� 
IsReadOnly$
 True��5#      5$      �� 5%      $ 
Horizontal=�6   .+�5&      �� $��Bottom=�6   $��	PersonId:��67   �� 5'      -   5        $ txtFullName��5(      $	��100��5)      $��	55,10,0,0q�5*      5+      �� 5,      $ 
Horizontal=�6   .+�5-      �� $��Bottom=�6   $��OrderAddress:��67   �� 5.      -   5        $ txtOrderAddress��5/      $	��100��50      $��	30,10,0,0q�51      52      �� 53      $ 
Horizontal=�6   .+�54      �� $��Bottom=�6   $��Phone Number:��67   �� 55      -   5        $ txtPhoneNumber��56      $	��100��57      $��	22,10,0,0q�58      59      �� 5:      $ 
Horizontal=�6   .+�5;      �� -   5         ��Name$ 	btnUpdate��5<      $	��206��5=      $��0,50,0,0q�5>      $��Update��5@      5A      5B      5C      5D      