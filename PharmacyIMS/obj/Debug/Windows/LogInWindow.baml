   M S B A M L   `   `   `  ����F  BPharmacyIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PharmacyIMS.WindowsPharmacyIMS.Windows  5   	   %    PharmacyIMS.Windows.LogInWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:PharmacyIMS.Windows     5   	     � Title$5  /Pharmacy Inventory Management System v.01.23.18��5   	   $	��300��6A   $	��300��6N    � 
ResizeMode$ NoResize=�6Z    � WindowStyle$ 
ToolWindow=�6q    � WindowState$ 	Maximized=�6�   .��5	      � ���#1569C7.+�5
   
   � .+�5      �� $��Bottom=�6   $��Right=�64   .+�5      �� 
�������$
��v0.5��6/   $��Right=�6;   �� 5      
�������$��Created by: RJ Jaleco��6/   5      � 5      $	��400��6   $	��400��6    ���#F5F5F5 � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   .+�5      �� -   5         ��Name$ TxtblkUsernameLogin��5      
�������$��25,200,25,5q�6K   $��1��6`   $��	 Username��6n   
�������$��20(�6�   �� 5      -   5         ��Name$ TxtbxUsernameLogin��5      $��25,200,25,5q�66   $��1��6K   
������ $��20(�6q   $	��4,0q�6   6�   �� 5      -   5        $ TxtblkPasswordLogin��5      
�������$
��25,5q�6K   $��2��6Y   $��	 Password��6f   
�������$��20(�6�   G� 5      -   5         G�Name$ TxtbxPasswordLogin��5      $
��25,2q�6:   $��2��6H   
������ $��20(�6n   $	��4,0q�6|   6�   �� 5      -   5         ��Name$ LogInBtn��5      $��Log In��6B   $��3��6S   $��20(�6`   $��25,10q�6n   	 �� 	IsDefault	 . 6}   5      5      5      5       