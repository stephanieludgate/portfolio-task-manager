   M S B A M L   `   `   `  ����F  BTaskProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TaskProject.pagesTaskProject.pages  5           TaskProject.pages.TaskPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:TaskProject.pages     5      -   5          N� Title$  TaskPage��5	      .��5      � 
������ $��10,10,40,20q�6$   $
��Auto��69    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��5q�6!   $��Center=�6,   .+�5      ��    Add#��[  6   $��20��62   �� 5      $��New Task��6   $��18(�6(   $	��5,0q�66   5      � 5   
   $��1��6   $��10q�6   $
��Left=�6(   $	��Top=�6C   .+�5      �� $��Information��6   $
��Auto��6,   $	��400��6:   $��10q�6F   .��5      �� .+�5      � .+�5      �� $��Task Name :��6    �� 5      -   5         ��Name$ warningName��5         Warning#��[ 65   $��20��6W   �� 5      -   5         ��Name$ validationName��5   $   $��Task name is required��6<   $��Center=�6Y   $��10(�5   $   $��Italic$�62   $	��5,0q�6E   5      �� 5      -   5         ��Name$ txtName��5      $��5q�6/   6;   � 5      .+�5       �� $��
Category :��6    �� 5!      -   5        $ warningCategory��5!       #��[ 69   $��20��6[   �� 5"      -   5        $ validationCategory��5"   $   $��Category is required��6@   $��Center=�6\   $��10(�5#   $   $��Italic$�62   $	��5,0q�6E   5$      �� 5%      -   5         ��Name$ 
cbCategory��5%       �� DisplayMemberPath$ CategoryName��6V    �� SelectedValuePath$ 
CategoryId��5&      $��Center=�6:   $
��Left=�6^   $	��120��5'      $��25��6'   $��5,0,0,0q�63    �� SelectedValue$ 0��6D   ��5%   3   �� *
Categories+5(      �� 5)      $��Description : ��6   �� 5*      -   5        $ txtDescription��5*      $��50��66   	 �� TextWrapping$
	 Wrap=�6B   $��5q�6V   �� 5+      
 �� Orientation$
 
Horizontal=�6!   $��0,10,0,0q�6:   .+�5,      �� -	   5         ��Name$ 	btnSubmit��5,   !   $
��Save��64   $��80��6C   
����  �
�������$��5q�5-   4   $��0,10,0,0q�6@   $��0q�6R   �� 5.      -
   5        $ 	btnCancel��5.   !   $��Cancel��64   $��80��6E   
�������
���   �$��5q�5/   4   $��	20,10,0,0q�6@   $��0q�6S   50      51      52      53      54      55      