   M S B A M L   `   `   `  ����@  <Test1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Test1.UserControlBarTest1.UserControlBar  5      +clr-namespace:Test1.ManageTest1.Manage  5          Test1.Manage.Admin   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Test1.UserControlBar     5      -local1clr-namespace:Test1.Manage     5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      -   5        $
��1000��5
      $	��450��5        � 
ResizeMode$  NoResize=�5       � WindowStyle$
 None=�5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��7��6   .+�5      '   !Test1.UserControlBar.ControlBarUC  -   5        5   !   5      � 5   
   $��1��6   .+�5      #  MaterialDesignThemes.Wpf.Card  .��5      ��  *  &MaterialDesignNavigationRailTabControl#��[  6    �� TabStripPlacement$
 left=�6]   .@�5      �� $��80��6   ��5      �� 5       $
��auto��6)   $
��auto��66   .+�5!   "   '  !MaterialDesignThemes.Wpf.PackIcon  $��30��5"   %   $��30��5#   %   $��0,0,0,3q�5$   %   $��Center=�5%   %      Kind$
 Home=�5&   %   �� 5'   "   $��Center=�6,   $
��Home��6I   5(      .��5*      �  � ColumnDefinitions 5+      �� 5,   "   $��20 �63   �� 5-   "   $��* �63   �� 5.   "   $
��0.5* �63   �� 5/   "   $��20 �63    51      �� 52   "   $��20 �60   �� 53   "   $��* �60   �� 54   "   $��* �60   �� 55   "   $��* �60   �� 56   "   $��20 �60   .+�58      �� $��2��59   !   $��1��5:   !   $��2��5;   !   $	��650��5<   !   $��1��5=   !   $��	10,10,0,0q�5>   !   $
��Left=�5?   !   $	��Top=�5@   !   
���   �!  System.Windows.SystemColors   AppWorkspaceBrushKey#���  5B   !    J� Opacity$	 0.2Q�5C   !   �� 5D      $��2��5E   !   $��2��5F   !   $��1��5G   !   $��1��5H   !   $	��220��5I   !   $��0,0,10,0q�5J   !   $��Right=�5K   !   $��Bottom=�5L   !   
���   �#���  5N   !   $	 0.2Q�5O   !   � 5P      $��1��5Q   !   $��1��5R   !   $��2��5S   !   $��	10,10,0,0q�5T   !    5U   "   �� 5V   &   $��* �67   �� 5W   &   $��* �67   �� 5X   &   $��* �67   .+�5Z   "   �� $��0��5[   %   $	��250��5\   %    �� Padding$ 20q�5]   %   ���	#FFDDDDDD	 �� CornerRadius$	 10��5_   %   $ 1Q�5`   %   ._�5a   &   �� .+�5b   *   �� $��16(�5c   -   $
��Bold"�5d   -   $��Total Persons��5e   -   
 �� TextAlignment$
 Center=�5f   -   �� 5g   *   $��0,20,0,0q�5h   -   $��Center=�5i   -   $��Center=�5j   -   $��18(�5k   -   $
��Bold"�5l   -    % !MaterialDesign.Brush.Primary.Dark#��[ 5m   -   ��5n   -   �� *TotalPersons+5o   '   5p   #   �� 5q   "   $��1��5r   %   $	��250��5s   %   $ 20q�5t   %   ���	#FFDDDDDD$	 10��5v   %   ._�5w   &   �� .+�5x   *   �� $��16(�5y   -   $
��Bold"�5z   -   $��Total Order��5{   -   $
 Center=�5|   -   �� 5}   *   $��0,20,0,0q�5~   -   $��Center=�5   -   $��Center=�5�   -   $��18(�5�   -   $
��Bold"�5�   -     ColorRedsolid#��[ 5�   -   ��5�   -   �� *
TotalOrder+5�   '   5�   #   �� 5�   "   $��2��5�   %   $	��250��5�   %   $ 20q�5�   %   ���	#FFDDDDDD$	 10��5�   %   ._�5�   &   �� .+�5�   *   �� $��16(�5�   -   $
��Bold"�5�   -   $��Your Wallet��5�   -   $
 Center=�5�   -   �� 5�   *   -   5         ��Name$ txtTotalMoneyUser��5�   -   $��0,20,0,0q�5�   -   $��Center=�5�   -   $��Center=�5�   -   $��18(�5�   -   $
��Bold"�5�   -   
��� � �5�   -   5�   '   5�   #   5�      � 5�      $��2��5�   !   $��2��5�   !   $��1��5�   !   .+�5�   "   �� $	��500��5�   %   $��0,30,0,0q�5�   %   $9��3E:\Asignment_PRN_212\Test1\Image\Karma is a Cat.jpg��5�   %   5�      5�      5�      �� 5�      $��80��6   ��5�      �� 5�      $
��auto��6)   $
��auto��66   .+�5�   "     $��30��5�   %   $��30��5�   %   $��0,0,0,3q�5�   %   $��Center=�5�   %   $ CardAccountDetails=�5�   %   �� 5�   "   $��Center=�6,   $��Profile��6I   5�      .��5�      �  5�      �� 5�   "   $��20 �63   �� 5�   "   $��* �63   �� 5�   "   $
��0.5* �63   �� 5�   "   $��20 �63    5�      �� 5�   "   $��20 �60   �� 5�   "   $
��0.5* �60   �� 5�   "   $��* �60   �� 5�   "   $��* �60   �� 5�   "   $��20 �60   .+�5�      �� $��2��5�   !   $��1��5�   !   $��2��5�   !   $	��670��5�   !   $��1��5�   !   $��	10,10,0,0q�5�   !   $
��Left=�5�   !   $	��Top=�5�   !   
���   �#���  5�   !   $	 0.2Q�5�   !   �� 5�      $��1��5�   !   $��1��5�   !   $��	10,10,0,0q�5�   !    �� Orientation$ Vertical=�5�   !   .+�5�   "   �� $��20(�5�   %   $
��Bold"�5�   %   $��
My Profile��5�   %   �� 5�   "   $��0,10,0,0q�6,   $6��0 Manage profile information for account security��6>   5�      �� 5�      $��2��5�   !   $��2��5�   !   $��1��5�   !   $��1��5�   !   $	��270��5�   !   $��0,0,10,0q�5�   !   $��Right=�5�   !   $��Bottom=�5�   !   
���   �#���  5�   !   $	 0.2Q�5�   !   �� 5�      $��2��5�   !   $��2��5�   !   $��2��5�   !   $��Center=�5�   !   $ Vertical=�5�   !   .+�5�   "   �� -   5         ��Name$ ProfileImage��5�   %   $	��100��5�   %   $	��100��5�   %   $��	0,30,0,30q�5�   %    J� Clip 5�   &   @� 5�   *    @� Center$ 50,50&�5�   -    @� RadiusX$ 50Q�5�   -    @� RadiusY$ 50Q�5�   -   5�   #   �� 5�   "   -   5         ��Name$ btnChoosePicture��5�   %   $	��150��5   %   $��0,0,0,20q�5  %   $��Center=�5  %   $��Choose Picture��5  %   �� 5  "   $��14(�5  %     ColorGrayBoder#��[ 5  %   $<��6 49 / 5.000 Maximum file size 1 MB Format: .JPEG, .PNG��5  %   $
 Center=�5	  %   $
��Wrap=�5
  %   5     � 5     $��2��5  !   $��2��5  !   $��1��5  !    5  "   �� 5  &   $
��0.5* �67   �� 5  &   $��* �67   .+�5  "   �� $��0��5  %   $	��187��5  %   $��Right=�5  %   $��Center=�5  %   .+�5  &   �� $��0,0,0,10q�5  )   $��15(�5  )   $��
User Name ��5  )   �� 5  &   $��0,8,0,10q�5  )   $��15(�5   )   $��
Full Name ��5!  )   $
 Right=�5"  )   �� 5#  &   $��0,5,0,0q�5$  )   $��15(�5%  )   $��Email ��5&  )   $
 Right=�5'  )   �� 5(  &   $��0,12,0,0q�5)  )   $��15(�5*  )   $��Number ��5+  )   $
 Right=�5,  )   �� 5-  &   $��0,10,0,0q�5.  )   $��15(�5/  )   $��Gender ��50  )   $
 Right=�51  )   �� 52  &   $��0,12,0,0q�53  )   $��15(�54  )   $��Birtday ��55  )   $
 Right=�56  )   57  #   �� 59  "   $��2��5:  %   $��15,0,0,0q�5;  %   $
��Left=�5<  %   $��Center=�5=  %   $ Vertical=�5>  %   .+�5?  &   �� $ 
Horizontal=�61   .+�5@  *   �� -   5         ��Name$ txtUserName��5A  -   $	��100��5B  -   $��	0,0,10,10q�5C  -    � Cursor$
 None��5D  -    �� 
IsReadOnly$
 True��5E  -   ]� 5F  *   .+�5G  .   �� $��Center=�5H  1   $��16(�5I  1   $��Role: ��5J  1   �� 5K  .   -   5        $ txtRoleAccount��5L  1   $��10,0,0,0q�5M  1   $��Center=�5N  1   $��16(�5O  1   $
��Bold"�5P  1   5Q  +   5R  '   �� 5S  &   -   5        $ txtFullName��5S  .   $��0,0,0,10q�6C   �� 5T  &   -	   5        $ txtEmail��5T  .   $��0,0,0,10q�6@   �� 5U  &   -
   5        $ txtPhoneNumber��5U  .   $��0,0,0,10q�6F   �� 5V  &   $��2��5W  )   $
��Left=�5X  )   $��Center=�5Y  )   $ 
Horizontal=�5Z  )   .+�5[  *   	� -   5         	�Name$ rdoMale��5\  -   $��0,0,20,0q�5]  -   $
��Male��5_  -    	� 	GroupName$ Gender��5`  -   	� 5a  *   -   5        $ 	rdoFeMale��5b  -   $��0,0,20,0q�5c  -   $��Female��5d  -   $ Gender��5e  -   	� 5f  *   -   5        $ rdoOther��5g  -   $��Other��5h  -   $ Gender��5i  -   5j  '   (  "System.Windows.Controls.DatePicker  5k  &   -   5          Name$ 
dpBirthday��5l  )   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��5m  )    ( $MaterialDesignFloatingHintDatePicker#��[ 5n  )   5o  #   �� 5p  "   -   5        $ btnSaveProFile��5q  %   $��2��5r  %   $	��100��5s  %   $��Center=�5t  %   $��Bottom=�5u  %     	ColorSave#��[ 5v  %   $
��Save��5w  %   5x     5y     5z     �� 5�     $��80��6   ��5�     �� 5�     $
��auto��6)   $
��auto��66   .+�5�  "     $��30��5�  %   $��30��5�  %   $��0,0,0,3q�5�  %   $��Center=�5�  %   $ PackageVariantClosed=�5�  %   �� 5�  "   $��Center=�6,   $��Products��6I   5�     .��5�     �  5�     �� 5�  "   $��* �60   �� 5�  "   $
��0.6* �60   .+�5�     � $��1��6#    5�  "   �� 5�  &   $��* �67   �� 5�  &   $
��0.6* �67   .+�5�  "   � $��0��6'    5�  &   �� 5�  *   $��* �6;   �� 5�  *   $��* �6;    5�  &   �� 5�  *   $��* �68   �� 5�  *   $
��0.5* �68   .+�5�  &   �� $��0��5�  )   $��Center=�5�  )   $ Vertical=�5�  )   .+�5�  *   �� $ 
Horizontal=�65   .+�5�  .   �� $��80��5�  1   $��0,0,20,0q�5�  1   $��Right=�5�  1   $��Center=�5�  1   $��
Product ID��5�  1   $
 Right=�5�  1   �� 5�  .   -   5        $ txtProductid��5�  6   $	��100��6L   5�  +   �� 5�  *   $ 
Horizontal=�65   .+�5�  .   �� $��80��5�  1   $��0,0,20,0q�5�  1   $��Center=�5�  1   $��Product Name��5�  1   $
 Right=�5�  1   �� 5�  .   -   5        $ txtProductName��5�  6   $	��100��6N   5�  +   �� 5�  *   $ 
Horizontal=�65   .+�5�  .   �� $��80��5�  1   $��0,0,20,0q�5�  1   $��Center=�5�  1   $��	Categrory��5�  1   $
 Right=�5�  1   �� 5�  .   -   5         ��Name$ cbxCateGrory��5�  1   $	��100��5�  1    �� DisplayMemberPath$ CategoryName��5�  1    �� SelectedValuePath$ 
CategoryId��5�  1    �� SelectedValue 5�  1   �� *
CategoryId+ �� Mode$ TwoWay=�5�  1   5�  +   �� 5�  *   $ 
Horizontal=�65   .+�5�  .   �� $��80��5�  1   $��0,0,20,0q�5�  1   $��Center=�5�  1   $��Description��5�  1   $
 Right=�5�  1   �� 5�  .   -   5        $ txtDescription��5�  6   $	��160��6N   5�  +   5�  '   �� 5�  &   $��1��5�  )   $��Center=�5�  )   $ Vertical=�5�  )   .+�5�  *   �� $ 
Horizontal=�65   .+�5�  .   �� $��50��5�  1   $��0,0,20,0q�5�  1   $��Right=�5�  1   $��Bottom=�5�  1   $��Stock��5�  1   $
 Right=�5�  1   �� 5�  .   -   5        $ txtStockProduct��5�  6   $	��100��6O   5�  +   �� 5�  *   $ 
Horizontal=�65   .+�5�  .   �� $��50��5�  1   $��0,0,20,0q�5�  1   $��Bottom=�5�  1   $��	Price($):��5�  1   $
 Right=�5�  1   �� 5�  .   -   5        $ txtPrice��5�  6   $	��100��6H   5�  +   5�  '   �� 5�  &   $��1��5�  )   $��0��5�  )   $��2��5�  )   $��Center=�5�  )   $��Center=�5�  )   $ 
Horizontal=�5�  )   .+�5�  *   �� -   5        $ btnCreateProduct��5�  -   $��80��5�  -   $��0,0,20,0q�5�  -   $��Create��5�  -   �� 5�  *   -   5        $ btnUpdateProduct��5�  -   $��80��5�  -   $��0,0,20,0q�5�  -   $��Update��5�  -   �� 5   *   -   5        $ btnClearProduct��5  -   $��80��5  -   $��0,0,20,0q�5  -   $��Clear��5  -   �� 5  *   -   5        $ 	btnDelete��5  -   $��80��5  -   $��0,0,20,0q�5	  -   $��Delete��5  -   5  '   5  #   �� 5  "   $��1��6-   $ Vertical=�6=   .+�5  &   � .+�5  *   �� -   5        $ ProductImage��5  -   $	��100��5  -   $	��100��5  -   $��0,0,0,20q�5  -   ��5  -   �� *ImangePathProduct+5  '   �� 5  &   -   5        $ btnBowseImageProduc��5  )   $	��100��5  )   $��Bownse��5  )   5  #   5     &   System.Windows.Controls.DataGrid  5"     -   5          Name$ DataGridProduct��5#  !   $��0��5$  !       AutoGenerateColumns$  False��5&  !   
���   �$��1q�5(  !   !   CanUserAddRows$! False��5)  !   "   HeadersVisibility$	" All=�5*  !   #   
IsReadOnly$
# True��5+  !   $   SelectionMode$$ Single=�5.  !   %   SelectionUnit$% FullRow=�5/  !   -  'MaterialDesignThemes.Wpf.DataGridAssist&   SelectedCellBorderBrush& 5%  !   Z� ��5,  !   �� *ProductList+'   Columns' 50  "   4	  .System.Windows.Controls.DataGridTemplateColumn	  52  &   ,
  &System.Windows.Controls.DataGridColumn( 
  Header( 53  *   �� 54  .   -   5        ) ��Name$) HeaderCheckbox��54  7   6O   * 	  CellTemplate* 56  *   �� 57  .   .R�58  2   �� + d� 	IsChecked+ 6;   �� *
IsSelected+$ TwoWay=�59  /   5;  '   0  *System.Windows.Controls.DataGridTextColumn  5>  &   , 
  Width5  /System.Windows.Controls.DataGridLengthConverter$
, auto 69   1  +System.Windows.Controls.DataGridBoundColumn-   Binding- 6F   �� *	ProductId+( 5?  *   �� 5@  .   $��	ProductId��68   .   ElementStyle. 5B  *   �� 5C  .   / �� 
TargetType"/ ��64   .�5D  2   �� 0 �� Property0 �@��TextAlignment1 �� Value$1 Center=�6R   �� 5E  2   0 � ��$1 Center=�6X   �� 5F  2   0 � ��$1 Center=�6V   5G  /   5I  '     5K  &   $
, auto 69   - 6F   �� *ProductName+( 5L  *   �� 5M  .   $
��Name��68   . 5O  *   �� 5P  .   "/ ��64   .�5Q  2   �� 0 �@��TextAlignment$1 Center=�6R   �� 5R  2   0 � ��$1 Center=�6X   �� 5S  2   0 � ��$1 Center=�6V   5T  /   5V  '     5X  &   $
, auto 69   - 6F   �� *ProductDescription+( 5Y  *   �� 5Z  .   $��Description��68   . 5\  *   �� 5]  .   "/ ��64   .�5^  2   �� 0 �@��TextAlignment$1 Center=�6R   �� 5_  2   0 � ��$1 Center=�6X   �� 5`  2   0 � ��$1 Center=�6V   5a  /   5c  '     5e  &   $
, auto 69   - 6F   �� *Stock+( 5f  *   �� 5g  .   $��Stock��68   . 5i  *   �� 5j  .   "/ ��64   .�5k  2   �� 0 �@��TextAlignment$1 Center=�6R   �� 5l  2   0 � ��$1 Center=�6X   �� 5m  2   0 � ��$1 Center=�6V   5n  /   5p  '     5r  &   $
, auto 69   - 6F   �� *Price+( 5s  *   �� 5t  .   $��Price��68   . 5v  *   �� 5w  .   "/ ��64   .�5x  2   �� 0 �@��TextAlignment$1 Center=�6R   �� 5y  2   0 � ��$1 Center=�6X   �� 5z  2   0 � ��$1 Center=�6V   5{  /   5}  '     5  &   $
, auto 69   - 6F   �� *	Storage+( 5�  *   �� 5�  .   $��
Categories��68   . 5�  *   �� 5�  .   "/ ��64   .�5�  2   �� 0 �@��TextAlignment$1 Center=�6R   �� 5�  2   0 � ��$1 Center=�6X   �� 5�  2   0 � ��$1 Center=�6V   5�  /   5�  '     5�  &   $
, auto 69   - 6F   �� *	CreatedAt+( 5�  *   �� 5�  .   $��	Create At��68   . 5�  *   �� 5�  .   "/ ��64   .�5�  2   �� 0 �@��TextAlignment$1 Center=�6R   �� 5�  2   0 � ��$1 Center=�6X   �� 5�  2   0 � ��$1 Center=�6V   5�  /   5�  '     5�  &   $
, auto 69   - 6F   �� *	UpdatedAt+( 5�  *   �� 5�  .   $��	Update At��68   . 5�  *   �� 5�  .   "/ ��64   .�5�  2   �� 0 �@��TextAlignment$1 Center=�6R   �� 5�  2   0 � ��$1 Center=�6X   �� 5�  2   0 � ��$1 Center=�6V   5�  /   5�  '   	  5�  &   ( 5�  *   �� 5�  .   $��Image��68   * 5�  *   �� 5�  .   .R�5�  2   �� $��50��5�  5   $��50��5�  5   ��5�  5   �� *ImagePathProduct+5�  /   5�  '   5�     5�     5�     �� 5�     $��80��6   ��5�     �� 5�     $
��auto��6)   $
��auto��66   .+�5�  "     $��30��5�  %   $��30��5�  %   $��0,0,0,3q�5�  %   $��Center=�5�  %   $ AccountGroupOutline=�5�  %   �� 5�  "   $��Center=�6,   $��Account��6I   5�     .��5�     �  5�     �� 5�  "   $��* �60   �� 5�  "   $
��0.5* �60   .+�5�       -   5        $ DataGridUsers��5�  !   $  False��5�  !   $! False��5�  !   $	" All=�5�  !   $
# True��5�  !   & 5�  !   Z� ��5�  !   �� *Items1+% 5�  !   �� 2 �� ElementName$2 selectionUnitComboBox��3 �� Path$3 SelectedValue�' 5�  "     5�  &   $, 70 69   - 6D   �� *Id+( 5�  *   �� 5�  .   $��ID��68   5�  '     5�  &   - 69   �� *
UserName+( 5�  *   �� 5�  .   $��	User Name��68   5�  '     5�  &   - 69   �� *
FullName+( 5�  *   �� 5�  .   $��	Full Name��68   5�  '     5�  &   - 69   �� *Age+( 5�  *   �� 5�  .   $	��Age��68   5�  '     5�  &   - 69   �� *Gender+( 5�  *   �� 5�  .   $��Gender��68   5�  '     5�  &   - 69   �� *RoleAccount+( 5�  *   �� 5�  .   $
��Role��68   5�  '     5�  &   $	, 150 69   - 6E   �� *PhoneNumber+( 5   *   �� 5  .   $��PhoneNumber��68   $
 Center=�6K   5  '     5  &   $	, 170 69   - 6E   �� *Email+( 5  *   �� 5  .   $��Email��68   $
 Center=�6E   5
  '     5  &   $	, 170 69   - 6E   �� *	Address+( 5  *   �� 5  .   $��address��68   5  '   5     � 5     $��1��6#    5  "   �� 5  &   $��* �67   �� 5  &   $
��0.6* �67   .+�5  "   � $��0��6'    5  &   �� 5  *   $
��Auto �6;   �� 5  *   $	��160 �6;   �� 5  *   $��80 �6;   �� 5  *   $
��Auto �6;   �� 5   *   $	��160 �6;    5#  &   �� 5$  *   $
��Auto �68   �� 5%  *   $
��auto �68   �� 5&  *   $
��Auto �68   �� 5'  *   $
��Auto �68   �� 5(  *   $
��Auto �68   .+�5,  &   �� $��0��5-  )   $��0��5.  )   $��Center=�5/  )   $	��ID:��50  )   $
 Right=�51  )   �� 52  &   -   5        $��txtUserIdAC��53  )   $��1��54  )   $	��140��55  )   $��Center=�56  )   ��57  )   �� *Id+$ TwoWay=��� 5:  &   $��0��5;  )   $��3��5<  )   $��Center=�5=  )   $��
User Name:��5>  )   $
 Right=�5?  )   �� 5@  &   -    5        $��txtUserNameAC��5A  )   $��0��5B  )   $��4��5C  )   $	��140��5D  )   ��5E  )   �� *
userName+$ TwoWay=��� 5H  &   $��1��5I  )   $��0��5J  )   $��Center=�5K  )   $��
Full Name:��5L  )   $
 Right=�5M  )   �� 5N  &   -!   5        $��txtFullNameAC��5O  )   $��1��5P  )   $��1��5Q  )   $	��140��5R  )   ��5S  )   �� *
FullName+$ TwoWay=��� 5V  &   $��1��5W  )   $��3��5X  )   $��Center=�5Y  )   $
��Age:��5Z  )   $
 Right=�5[  )   �� 5\  &   -"   5        $��txtAgeAC��5]  )   $��1��5^  )   $��4��5_  )   $	��140��5`  )   ��5a  )   �� *Age+$ TwoWay=��� 5d  &   $��2��5e  )   $��0��5f  )   $��Center=�5g  )   $��Gender:��5h  )   $
 Right=�5i  )   �� 5j  &   -#   5        $��txtGenderAC��5k  )   $��2��5l  )   $��1��5m  )   $	��140��5n  )   ��5o  )   �� *Gender+$ TwoWay=��� 5r  &   $��2��5s  )   $��3��5t  )   $��Center=�5u  )   $��Address:��5v  )   $
 Right=�5w  )   �� 5x  &   -$   5        $��
txtAddress��5y  )   $��2��5z  )   $��4��5{  )   $	��140��5|  )   ��5}  )   �� *	Address+$ TwoWay=��� 5�  &   $��3��5�  )   $��0��5�  )   $��Center=�5�  )   $��Phone Number:��5�  )   $
 Right=�5�  )   �� 5�  &   -%   5        $��txtPhoneNumberAC��5�  )   $��3��5�  )   $��1��5�  )   $	��140��5�  )   ��5�  )   �� *PhoneNumber+$ TwoWay=��� 5�  &   $��4��5�  )   $��0��5�  )   $��0,0,10,0q�5�  )   $��Bottom=�5�  )   $��Role:��5�  )   $
 Right=�5�  )   �� 5�  &   $��4��5�  )   $��1��5�  )   $��0,0,10,0q�5�  )   $
��Left=�5�  )   $��Bottom=�5�  )   $ 
Horizontal=�5�  )   .+�5�  *   	� -&   5        $ rdoAdmin��5�  -   $��0,0,20,0q�5�  -   $��Admin��5�  -   $
 Role��5�  -   	� 5�  *   -'   5        $ rdoCustomer��5�  -   $��0,0,20,0q�5�  -   $��Customer��5�  -   $
 Role��5�  -   5�  '   �� 5�  &   $��3��5�  )   $��3��5�  )   $��Center=�5�  )   $��Email:��5�  )   $
 Right=�5�  )   �� 5�  &   -(   5        $��
txtEmailAC��5�  )   $��3��5�  )   $��4��5�  )   $	��140��5�  )   ��5�  )   �� *Email+$ TwoWay=��� 5�  &   $��4��5�  )   $��3��5�  )   $��Center=�5�  )   $��
PassWord: ��5�  )   $
 Right=�5�  )   G� 5�  &   -)   5        4 G�Name$4 pswdAC��5�  )   $��4��5�  )   $��4��5�  )   $	��150��5�  )   5�  #   �� 5�  "   $��1��6-   $ Vertical=�6=   .+�5�  &   �� $��Center=�61   $ 
Horizontal=�6N   .+�5�  *   �� $��0��5�  -   $��0��5�  -   $��10q�5�  -   $��Center=�5�  -   $��Search By Name:��5�  -   �� 5�  *   -*   5        $ txtSearchAC��5�  -   $��0��5�  -   $��1��5�  -   $	��150��5�  -   $��5q�5�  -   5�  '   � 5�  &    5�  *   �� 5�  .   $��* �6?   �� 5�  .   $��* �6?   .+�5�  *   �� -+   5        $ btnCreateAC��5�  -   $��0��5�  -   $	��100��5�  -   $��5q�5�  -     ColorSubmit#��[ 5�  -   $��Create��5�  -   �� 5�  *   -,   5        $ btnSearchAC��5�  -   $��1��5�  -   $	��100��5�  -   $��5q�5�  -     PrimaryHueMidBrush#��[ 5�  -   $��Search��5�  -   5�  '   � 5�  &    5�  *   �� 5�  .   $��* �6?   �� 5�  .   $��* �6?   .+�5�  *   �� --   5        $ btnUpdateAC��5�  -   $��0��5�  -   $	��100��5�  -   $��5q�5�  -   #��[ 5�  -   $��Update��5�  -   �� 5�  *   -.   5        $ btnDeleteAC��5�  -   $��1��5�  -   $	��100��5�  -   $��5q�5�  -   #��[ 5�  -   $��Delete��5  -   5  '   5  #   5     5     5     �� 5     $��80��6   ��5     �� 5     $
��auto��6)   $
��auto��66   .+�5  "     $��30��5  %   $��30��5  %   $��0,0,0,3q�5  %   $��Center=�5  %   $ 	Clipboard=�5  %   �� 5  "   $��Center=�6,   $��Bills��6I   5     .��5     � $��16q�6   .+�5       -/   5        $ DataGridYourHistory��5  !   $��0��5  !   $  False��5  !   
���   �$��1q�5   !   $! False��5!  !   $	" All=�5"  !   $
# True��5#  !   $$ Single=�5'  !   $% FullRow=�5(  !   & 5  !   Z� ��5$  !   �� *ItemHistoryBills+' 5)  "     5+  &   $
, auto 69   - 6F   �� *	OrderId+( 5,  *   �� 5-  .   $��14(�68   $��Order ID��6F   . 5/  *   �� 50  .   "/ ��64   .�51  2   �� 0 �@��TextAlignment$1 Center=�6R   �� 52  2   0 � ��$1 Center=�6X   �� 53  2   0 � ��$1 Center=�6V   54  /   56  '     59  &   $, 80 69   - 6D   �� *ReceiverName+( 5:  *   �� 5;  .   $��14(�68   $
��Name��6F   . 5=  *   �� 5>  .   "/ ��64   .�5?  2   �� 0 �@��TextAlignment$1 Center=�6R   �� 5@  2   0 � ��$1 Center=�6X   �� 5A  2   0 � ��$1 Center=�6V   5B  /   5D  '     5G  &   $, 80 69   - 6D   �� *ReceiverPhone+( 5H  *   �� 5I  .   $��14(�68   $��Phone��6F   . 5K  *   �� 5L  .   "/ ��64   .�5M  2   �� 0 �@��TextAlignment$1 Center=�6R   �� 5N  2   0 � ��$1 Center=�6X   �� 5O  2   0 � ��$1 Center=�6V   5P  /   5R  '     5U  &   -0   5        txtTotalPrice��$, 80 5W  )   - 5X  )   �� *TotalQuantity+( 5Y  *   �� 5Z  .   $��14(�68   $��Total Quantity��6F   . 5\  *   �� 5]  .   "/ ��64   .�5^  2   �� 0 �@��TextAlignment$1 Center=�6R   �� 5_  2   0 � ��$1 Center=�6X   �� 5`  2   0 � ��$1 Center=�6V   5a  /   5c  '   	  5f  &   $	, 130 6=   $( Total Amount��6I   * 5g  *   �� 5h  .   .R�5i  2   �� $
��Bold"�5j  5   $
 Center=�5l  5   ��5k  5   �� *
TotalPrice+5 �� StringFormat$5 C2����5m  6   �� 5n  :   "/ ��6@   .�5o  >   �� 0 � ��
1 � � �6[   5p  ;   5r  3   5s  /   5u  '     5w  &   $
, auto 69   - 6F   �� *Description+( 5x  *   �� 5y  .   $��14(�68   $��Description��6F   . 5{  *   �� 5|  .   "/ ��64   .�5}  2   �� 0 �@��TextAlignment$1 Center=�6R   �� 5~  2   0 � ��$1 Center=�6X   �� 5  2   0 � ��$1 Center=�6V   5�  /   5�  '     5�  &   $	, 140 69   - 6E   �� *	OrderDate+( 5�  *   �� 5�  .   $��14(�68   $��Create Update��6F   . 5�  *   �� 5�  .   "/ ��64   .�5�  2   �� 0 �@��TextAlignment$1 Center=�6R   �� 5�  2   0 � ��$1 Center=�6X   �� 5�  2   0 � ��$1 Center=�6V   5�  /   5�  '     5�  &   $
, auto 69   - 6F   �� *ContentOrder+( 5�  *   �� 5�  .   $��14(�68   $��Content��6F   . 5�  *   �� 5�  .   "/ ��64   .�5�  2   �� 0 �@��TextAlignment$1 Center=�6R   �� 5�  2   0 � ��$1 Center=�6X   �� 5�  2   0 � ��$1 Center=�6V   5�  /   5�  '   	  5�  &   $
, auto 6=   $( Status��6J   * 5�  *   �� 5�  .   .R�5�  2   �� $
��Bold"�5�  5   $
 Center=�5�  5   ��5�  5   �� *OrderStatus+��5�  6   �� 5�  :   "/ ��6@   .�5�  >   �� 0 � ��
1 �����6[   6 �� Triggers6 5�  >   �� 5�  B   7 �� Binding7 6N   �� *OrderStatus+8 �� Value8 Pressing...6n   .a�5�  F   �� 0 � ��
1 � ���6c   5�  C   �� 5�  B   7 6N   �� *OrderStatus+8 Pending6n   .a�5�  F   �� 0 � ��
1 � � �6c   5�  C   �� 5�  B   7 6N   �� *OrderStatus+8 Done6n   .a�5�  F   �� 0 � ��
1 ��  �6c   5�  C   �� 5�  B   7 6N   �� *OrderStatus+8 	Cancelled6n   .a�5�  F   �� 0 � ��
1 �  ��6c   5�  C   5�  ;   5�  3   5�  /   5�  '   5�     �� 5�     -1   5        $ 
btnRefresh��5�  !   $	��100��5�  !   $��30��5�  !   $��10q�5�  !   $��Right=�5�  !   $��Bottom=�5�  !   $��Refresh��5�  !   5�     5�     5�     5�     5�     5�     5�     