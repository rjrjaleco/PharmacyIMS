   M S B A M L   `   `   `  ����F  BPharmacyIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PharmacyIMS.WindowsPharmacyIMS.Windows  5   	   +    %PharmacyIMS.Windows.AddSupplierWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:PharmacyIMS.Windows     5   	     � Title$  Add Supplier��5   	   $	��300��6   $	��300��6+   ���#0066FF.��5	      � $��5q�6    � ColumnDefinitions 5
   
   �� 5      $
��Auto �5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��13(�6   
�������$��Center=�65   $��Supplier Name:��6P   �� 5   
   $��13(�6   
�������$��Center=�65   $��Supplier Address:��6P   $��1��6i   �� 5   
   $��13(�6   
�������$��Center=�65   $��Supplier Details:��6P   $��3��6i   �� 5   
   -   5         ��Name$ SupplierNameTbx��5       $��13(�6   $��1��69   $��5q�6I   �� 5   
   -   5        $ SupplierAddressTbx��5       $��13(�6   $��1��6<    �� TextWrapping$
 Wrap=�6L   $��2��6`   $��5q�6q   $��1��6|   �� 5   
   -   5        $ SupplierDetailsTbx��5       $��13(�6   $��4��6<   $
 Wrap=�6M   $��1��6a   $��5q�6q   $��3��6|   �� 5!   
   $��7��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Center=�6O   .+�5"      �� -   5         ��Name$ AddSupplierBtn��5"   T   $��13(�6   $��0q�6#   $	��Add��6l   $��5q�6z   $	��100��6�   �� 5#      -   5        $ CancelSupplierBtn��5#   W   $��13(�6   $��0q�6#   $��Cancel��6r   $��5q�6�   $	��100��6�   5$      5%      5&      