   M S B A M L   `   `   `  ����F  BPharmacyIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PharmacyIMS.WindowsPharmacyIMS.Windows  5   	   5    /PharmacyIMS.Windows.AddNewOrderToDeliveryWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:PharmacyIMS.Windows     5   	   ���#0066FF  � Title$  Add Orders to Delivery��5   	   $	��300��6(   $	��600��65   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��	10,5,15,5q�6.   .+�5      �� $��13(�6   
�������$��Delivery ID: ��69   �� 5      $��13(�6   
���������69   ��  �� Path$ SelectedDelivery.ID�5      �� 5   
   $��1��6   $ 
Horizontal=�6%   $��5,5,15,5q�6>   .+�5      �� $��13(�6   
�������$��
Supplier: ��69   �� 5      $��13(�6   
���������69   �� $4 .SelectedDelivery.SupplierDelivery.SupplierName�5      � 5   
   $��1��6   $��3��6   $��5q�60    5      �� 5      �� 5      $
��Auto �6#   �� 5      .+�5!      � $��5q�6    5"      �� 5#      $
��Auto �6$   �� 5$      $��* �6$   �� 5%      $
��Auto �6$   .+�5'      � $��0,5,5,0q�6   $��1��6(    5(      �� 5)      $	��.2* �6+   �� 5*      $��* �6+   �� 5+      $��* �6+   .+�5-      � -   5         �Name$ helperField1��5-   ,   $��0��6   6,   � 5.      -   5        $ helperField2��5.   ,   $��1��6   6,   � 5/      -   5        $ helperField3��5/   ,   $��2��6   6,   50      �� 51      $��Medium"�6   $��15(�60   
�������$��SUPPLIER PRODUCTS��6Q   �� 52      -   5         ��Name$ SupplierProductListView��52      $��1��6�   ��6<   �� $; 5SelectedDelivery.SupplierDelivery.SupplierProductList� �� View 53      �� 54      ! �� ColumnHeaderContainerStyle 55      �� 56   "   	 �� 
TargetType"	 ��6(   .�57   &   �� 
 �� Property
 � {� �� Value .  6B   58   #   .P�5:      �� $��ID��6-    �� Width 69   ��  �� ElementName$ helperField1��$ ActualWidth� �� DisplayMemberBinding 6v   �� $ ID��� 5;      $��Product Name��6-    6C   �� $ helperField2��$ ActualWidth� 6�   �� $ ProductName��� 5<      $��Generic Name��6-    6C   �� $ helperField3��$ ActualWidth� 6�   �� $ GenericName�5=      5?      � 5@      $��2��6    5A      �� 5B      $
��Auto �6+   �� 5C      $
��0.3* �6+   �� 5D      .+�5F      �� $��13(�6    
�������$��
Quantity: ��6A   $��Center=�6S   �� 5G      -   5         ��Name$ QuantityTbx��5G   -   $��13(�6   $��1��6B   $��Center=�6R   �� 5H      -   5         ��Name$ AddProductOrderBtn��5H   `   $��13(�6   $��0q�6+   $��Center=�6|   $��5,5,0,5q�6�   $��2��6�   $��	Add Order��6�   5I      5K      �� 5L      $��1��6   $��Stretch=�6+   $��Stretch=�6G   $��2��6e   
�������6o   � 5M      $��2��6   $��5q�6#    5N      �� 5O      $
��Auto �6$   �� 5P      $��* �6$   �� 5Q      $
��Auto �6$   .+�5S      � $��0,5,5,0q�6   $��1��6(    5T      �� 5U      $��* �6+   �� 5V      $��* �6+   .+�5X      � -   5        $ helperField4��5X   ,   $��0��6   6,   � 5Y      -   5        $ helperField5��5Y   ,   $��1��6   6,   5Z      �� 5[      $��Medium"�6   $��15(�61   
�������$��
ORDER LIST��6R   �� 5\      -	   5        $ OrderListView��5\      $��1��6r   ��62   �� $( "SelectedDelivery.DeliveryOrderList� 5]      �� 5^       5_      �� 5`   "   "	 ��6(   .�5a   &   �� 
 � {� .  6B   5b   #   .P�5d      �� $��Product Name��6-    6C   �� $ helperField4��$ ActualWidth� 6�   �� $ OrderProduct.ProductName��� 5e      $��Quantity��6-    6?   �� $ helperField5��$ ActualWidth� 6|   �� $ Quantity�5f      5h      5i      5j      5k      5l      