   M S B A M L   `   `   `  ����  WpfApp1    WpfApp1.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  
MainWindow��5   	   $	��500��6   $
��1000��6)   .��5      �� $
��Auto=�6   $
��Auto=�68   .��5	   
   � .+�5
      �� .+�5      �� $��Center=�6   .��65   Список дежурных6F   �� 5      -   5        $��StudentsBox��5      $��Center=�6-   ��6Q   �� *
Attendants+��5      �� 5      .R�5      �� ��6(   �� *
FullInfo+5      5      �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�5      �� $�� 0 8 5 0q�6   $��Center=�6.   .��6I   ?=Количество добавляемых дежурных:6k   �� 5      -   5        $��CountBox��5      $��20��6.   $��20��6<   $��	 0 10 5 0q�6K   $��Center=�5      $��Center=�5      �� 5      -   5        $��	 0 10 5 0q�5   ;   .��6N   64Добавить случайных дежурных6k   �� 5      $ Vertical=�6!   .+�5      �� $�� 0 8 5 0q�6    .��62   42Выбрать дежурных из списка:6O   �� 5      -   5        $��StudentComboBox��5   #   $	��300��6:   $��30��6F   $��0 0 0 0 q�6R   ��5   #   �� *
Students+��5      �� 5   "   .R�5    &   �� $ 
Horizontal=�61   .+�5!   *   �� $��0,0,10,0q�6]    d� 	IsChecked 63   �� *IsDuty+ �� Mode$ TwoWay=�6]   �� 5"   *   $��Center=�6N   ��64   �� *
FullInfo+6k   5#   '   5$   #   5&      5'      �� 5(      -   5        $��	 5 10 0 0q�5(   8   .��6K   Очистить6U   5)      5*      5+      5,      5-      