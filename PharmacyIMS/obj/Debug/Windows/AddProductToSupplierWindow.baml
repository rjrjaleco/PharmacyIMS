   M S B A M L   `   `   `  ����F  BPharmacyIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PharmacyIMS.WindowsPharmacyIMS.Windows  5   	   4    .PharmacyIMS.Windows.AddProductToSupplierWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:PharmacyIMS.Windows     5   	   ���#0066FF  � Title$  Add a Product to Supplier��5   	   $	��300��6+   $	��300��68   .��5	      � $��5q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   � $y�Visible=�6   $��5q�6$   $��2��6/   $��2��6<    5      �� 5      $	��.2* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      � -   5         �Name$ helperField1��5   $   $��0��6   6$   � 5      -   5        $ helperField2��5   $   $��1��6   6$   � 5      -   5        $ helperField3��5   $   $��2��6   6$   � 5      -   5        $ helperField4��5   $   $��3��6   6$   5      �� 5    
    �� Orientation$ 
Horizontal=�6   .+�5!      �� $��Medium"�6   
�������$��16(�6?   $
��ID: ��6M   �� 5"      -   5         ��Name$ SelectedSupplierIDTblk��5"   9   
�������$��16(�6+   ��6Y   ��  �� Path$ SelectedSupplier.ID�5#      �� 5$   
   $��Medium"�6   
�������$��16(�6<   $��1��6K   $��Selected Supplier: ��6X   �� 5%   
   
�������$��16(�6(   $��1��66   $��1��6C   ��6S   �� $# SelectedSupplier.SupplierName��� 5&   
   -   5         ��Name$ ProductListView��5&      $	��0,5q�6,   $��2��69   $��2��6F   $��12(�6�   
���   ���6Z   �� $ ProductList� �� View 5'      �� 5(      !	 �� ColumnHeaderContainerStyle	 5)      �� 5*      
 �� 
TargetType"
 ��6    .�5+      ��  �� Property � {� �� Value .  6:   5,      .P�5.      �� $��ID��6%    �� Width 61   ��  �� ElementName$ helperField1��$ ActualWidth� �� DisplayMemberBinding 6n   �� $ ID��� 5/      $��Product Name��6%    6;   �� $ helperField2��$ ActualWidth� 6x   �� $ ProductName��� 50      $��Generic Name��6%    6;   �� $ helperField3��$ ActualWidth� 6x   �� $ GenericName�52      54      �� 55   
   $ 
Horizontal=�6   $��3��6.   $��2��6;   $��5q�6O   $��Center=�6Z   .+�56      �� -   5         ��Name$ AddBtn��56   L   $��13(�6   $��0q�6#   $	��Add��6\   $	��5,0q�6j   $	��100��6w   �� 57      -   5        $ 	CancelBtn��57   O   $��13(�6   $��0q�6#   $��Cancel��6b   $	��5,0q�6s   $	��100��6�   58      59      5:      