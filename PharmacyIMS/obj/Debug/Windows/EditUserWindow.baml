   M S B A M L   `   `   `  ����F  BPharmacyIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PharmacyIMS.WindowsPharmacyIMS.Windows  5   	   (    "PharmacyIMS.Windows.EditUserWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:PharmacyIMS.Windows     5   	     � Title$  Change User Details��5   	   $	��200��6%   $	��300��62   ���#0066FF.��5	      � $��5q�6    � RowDefinitions 5
   
   �� 5      �� 5      $
��Auto �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��13(�6   $��5q�6&   
�������$��Right=�6D   $��
Username: ��6`   $��0��6r   �� 5      $��13(�6   $��5q�6&   
�������$��Right=�6D   $��New Password: ��6`   $��1��6v   �� 5      $��13(�6   $��5q�6&   
�������$��Right=�6D   $��Confirm Password: ��6`   $��2��6z   �� 5      -   5         ��Name$ UsernameTbx��5   %   $��13(�6   $��1��6Y   $��0��6i   $��5q�6v   ��6:   ��  �� Path$ Username�6v   G� 5      -   5         G�Name$ PasswordTbx��5   (   $��13(�6   $��1��6=   $��1��6M   $��5q�6Z   G� 5      -   5        $ PasswordConfirmTbx��5   (   $��13(�6   $��1��6D   $��2��6T   $��5q�6a   5      � 5    
   $��1��6    5!      �� 5"      �� 5#      .+�5%      �� -   5         ��Name$ 
SaveButton��5%   B   $��0q�6   $��0��6V   $	��5,0q�6f   $��Save Changes��6s   �� 5&      -   5        $ CancelButton��5&   D   $��0q�6   $��1��6Z   $	��5,0q�6j   $��Cancel��6w   5'      5(      5)      