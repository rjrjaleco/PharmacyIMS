   M S B A M L   `   `   `  ����F  BPharmacyIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PharmacyIMS.WindowsPharmacyIMS.Windows  5   	   *    $PharmacyIMS.Windows.AddProductWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:PharmacyIMS.Windows     5   	     � Title$  Add Product��5   	   $	��300��6   $	��300��6*   ���#0066FF.��5	      � $��5q�6    � ColumnDefinitions 5
   
   �� 5      $
��Auto �5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��13(�6   
�������$��Center=�65   $��Product Name:��6P   �� 5   
   $��13(�6   
�������$��Center=�65   $��Generic Name:��6P   $��1��6e   �� 5   
   $��13(�6   
�������$��Center=�65   $��Type:��6P   $��2��6]   �� 5   
   $��13(�6   
�������$��Center=�65   $��Form:��6P   $��3��6]   �� 5   
   $��13(�6   
�������$��Center=�65   $��Buying Price:��6P   $��4��6e   �� 5   
   $��13(�6   
�������$��Center=�65   $��Selling Price:��6P   $��5��6f   �� 5   
   $��13(�6   
�������$��Center=�65   $��	Quantity:��6P   $��6��6a   �� 5!   
   -   5         ��Name$ ProductNameTbx��5!       $��13(�6   $��1��6Z   $��5q�6j   ��68   ��  �� Path$ ProductName�6j   �� 5"   
   -   5        $ GenericNameTbx��5"       $��13(�6   $��1��6Z   $��5q�6j   $��1��6u   ��68   �� $ GenericName�6u   �� 5#   
   -   5        $ TypeTbx��5#       $��13(�6   $��1��6L   $��5q�6\   $��2��6g   ��61   �� $
 Type�6g   �� 5$   
   -   5        $ FormTbx��5$       $��13(�6   $��1��6L   $��5q�6\   $��3��6g   ��61   �� $
 Form�6g   �� 5%   
   -   5        $ BuyingPriceTbx��5%       $��13(�6   $��1��6Z   $��5q�6j   $��4��6u   ��68   �� $ BuyingPrice�6u   �� 5&   
   -   5        $ SellingPriceTbx��5&       $��13(�6   $��1��6\   $��5q�6l   $��5��6w   ��69   �� $ SellingPrice�6w   �� 5'   
   -   5        $ QuantityTbx��5'       $��13(�6   $��1��6T   $��5q�6d   $��6��6o   ��65   �� $ Quantity�6o   �� 5)   
   $��7��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Center=�6O   .+�5*      �� -   5         ��Name$ AddProductBtn��5*   7   $��13(�6   $��0q�6#   $	��Add��6j   $��5q�6x   $	��100��6�   �� 5+      -	   5        $ CancelProductBtn��5+   7   $��13(�6   $��0q�6#   $��Cancel��6p   $��5q�6�   $	��100��6�   5,      5-      5.      