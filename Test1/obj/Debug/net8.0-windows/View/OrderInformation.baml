   M S B A M L   `   `   `  ����@  <Test1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Test1.UserControlBarTest1.UserControlBar  5      !    Test1.View.OrderInformation   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Test1.UserControlBar     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  OrderInformation��5      $	��400��5	      $	��450��5
       � WindowStyle$
 None=�5      .��5      � .+�5   
   � $��0��6   $��7��6   .+�5      '   !Test1.UserControlBar.ControlBarUC  5      �� 5   
   $��Center=�5      $��Center=�5       �� Orientation$ Vertical=�5      .+�5      �� $��	0,30,0,20q�5      $��Center=�5      $��25(�5      $
��Bold"�5      $��Order Information��5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Bottom=�6   $��OrderId:��67   �� 5      -   5         ��Name$ 
txtOrderID��5      $	��100��5      $��80,0,0,0q�5        �� 
IsReadOnly$
 True��5!      5"      �� 5#      $ 
Horizontal=�6   .+�5$      �� $��Bottom=�6   $��Name:��67   �� 5%      -   5        $ txtFullName��5&      $	��100��5'      $��	90,10,0,0q�5(      5)      �� 5*      $ 
Horizontal=�6   .+�5+      �� $��Bottom=�6   $��OrderAddress:��67   �� 5,      -   5        $ txtOrderAddress��5-      $	��100��5.      $��	50,10,0,0q�5/      50      �� 51      $ 
Horizontal=�6   .+�52      �� $��Bottom=�6   $��Phone Number:��67   �� 53      -   5        $ txtPhoneNumber��54      $	��100��55      $��	42,10,0,0q�56      57      �� 58      $ 
Horizontal=�6   .+�59      �� $��Bottom=�6   $��Description:��67   �� 5:      -   5        $ txtDescription��5;      $	��100��5<      $��	62,10,0,0q�5=      5>      �� 5?      $ 
Horizontal=�6   $��0 10 0 0q�62   .+�5@      �� $��Bottom=�6   $��Total Quantity:��67   �� 5A      -   5         ��Name$ txtQuantity��5B      $	��100��5C      $��	50,10,0,0q�5D      5E      �� 5F      $ 
Horizontal=�6   $��0 10 0 0q�62   .+�5G      �� $��Bottom=�6   $��Total Price:��67   �� 5H      -   5        $ txtTotalPrice��5I      $	��100��5J      $��16(�5L      $��70,0,0,0q�5M      5N      �� 5P      $ 
Horizontal=�6   .+�5Q      �� -   5         ��Name$ 	btnAccept��5R      $	��106��5S      $��0,50,0,0q�5T      
��� � �
��� � �$��Accept��5X      �� 5Y      -	   5        $ 	btnReject��5Z      $	��106��5[      
���  ��
���  ��$��	40,50,0,0q�5^      $��Reject��5`      5a      5b      5c      5d      