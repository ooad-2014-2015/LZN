   M S B A M L   `   `   `  ����  AdministratorForme)    #AdministratorForme.FinansijePocetna   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  	Finansije��5   	   $	��340��6   $	��627��6(    � 
ResizeMode$ NoResize=�64    � WindowStartupLocation$ CenterScreen=�6J   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��338* �6   �� 5      $
��283* �6    � RowDefinitions 5
   
   �� 5      $	��15* �6   �� 5      $
��162* �6   �� 5      $	��13* �6   �� 5      $	��24* �6   �� 5      $	��61* �6   �� 5      $	��32* �6   �� 5      $��5* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��tabela��5         
IsReadOnly .    AutoGenerateColumns . $��1��6t   $��2��6�   $��	21,0,10,0q�6�   ��63   ��  �� Source$ racuni��   Columns 5      5      (  "System.Windows.Controls.DatePicker  5   
   -   5        $��datum��5      $��3��6"   $��135,0,171,0q�6/   �� 5   
   -   5        $��3��5      $��	87,0,10,0q�6   $��1��61   .��6W   	Pretraži6a   �� 5   
   -   5        $��Printaj izvjestaj��5      $��1��6-   $
��Left=�6=   $��87,0,0,0q�6X   $��5��6j   $	��Top=�6w   $	��186��6�   $��27��6�   6�   �� 5   
   $��Izvještaj za datum��6   $
��Left=�6-   $��21,0,0,0q�6H   $��3��6Z   $	��Top=�6g   $��24��6   $	��104��6�   5      5      