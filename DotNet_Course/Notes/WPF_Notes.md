#     <a href="https://docs.microsoft.com/en-us/dotnet/desktop/wpf/overview/?view=netdesktop-5.0">  Section13:  WPF </a>

+ XAML : Extensible Application Markup Language.

## 1.   **The built-in WPF controls are listed here:**
+
1. Buttons:
+  Button and RepeatButton.
2. Data Display:
 +  DataGrid, ListView, and TreeView.
3. Date Display and Selection:
 +  Calendar and DatePicker.
4. Dialog Boxes:
 +  OpenFileDialog, PrintDialog, and SaveFileDialog.
5. Digital Ink:
+  InkCanvas and InkPresenter.
6. Documents:
+ DocumentViewer, FlowDocumentPageViewer, FlowDocumentReader, FlowDocumentScrollViewer, and StickyNoteControl.
7. Input:
+  TextBox, RichTextBox, and PasswordBox.
8. Layout:
+ Border, BulletDecorator, Canvas, DockPanel, Expander, Grid, GridView, GridSplitter, GroupBox, Panel, ResizeGrip, Separator, ScrollBar, ScrollViewer, StackPanel, Thumb, Viewbox, VirtualizingStackPanel, Window, and WrapPanel.
9. Media: 
+ Image, MediaElement, and SoundPlayerAction.
10. Menus:
+ ContextMenu, Menu, and ToolBar.
11. Navigation:
+ Frame, Hyperlink, Page, NavigationWindow, and TabControl.
12. Selection:
+  CheckBox, ComboBox, ListBox, RadioButton, and Slider.
13. User Information:
+ AccessText, Label, Popup, ProgressBar, StatusBar, TextBlock, and ToolTip.


## 2. **WPF includes several layout controls:**
1. Canvas: 
 + Child controls provide their own layout.

2. DockPanel:
 +  Child controls are aligned to the edges of the panel.

3. Grid:
 +  Child controls are positioned by rows and columns.

4. StackPanel:
 +  Child controls are stacked either vertically or horizontally.

5. VirtualizingStackPanel:
 +  Child controls are virtualized and arranged on a single line that is either horizontally or vertically oriented.

6. WrapPanel: 
 + Child controls are positioned in left-to-right order and wrapped to the next line when there isn't enough space. on the current line.

## 3. <a href="https://docs.microsoft.com/en-us/dotnet/desktop/wpf/advanced/routed-events-overview?view=netframeworkdesktop-4.8"> Routed Events </a>
+ 
1. Routed events: WPF mechanism to handle events
2. Direct routed Event: handled by the item itself.
+  e.g. Click event
3. Bubbling event: 
+ Bubbling happens when the event is not handled by the element
+ if event is not handled by the element , it goes up the visual tree to higher element like from a button to Grid , 
+ unit the event is handled or the event "escapes" the top most element.
+ eg: MouseButtonDown or KeyDown event
3. Tunneling event: 
+ Tunneling is Opposite or Bubbling ,So instead  of an event going "up" the visual tree
+ the event travels down the visual tree towards the element that is considered the source
+ for WPF all tunneling event name  starts with "preview"
+ eg:  PreviewMouseUp
+ goes down the visual tree to "target" element 

```xml
  <Button Content="Click for  Buubling event" 
                MouseUp="Button_MouseUp"              
                Click="Button_Click" Width="150" Height="100"></Button>

   <Button Content="Click for tunneling event" 
   PreviewMouseUp="Button_PreviewMouseUp"
   Click="Button_Click" Width="150" Height="100"></Button>
```

+ <a href="http://csharphelper.com/blog/2015/03/understand-event-bubbling-and-tunneling-in-wpf-and-c/">Explainedand Demo:  Routed Event</a>

## 4. Dependency Property
+ our UI has Controls and these controls provide us different properties called Dependecy Properties , which can be set dynamically, at runtime 
+  same as Bindable Property in Xamarin 
+ example of button with its DP
```xml
        <Button Height="100" Width="200" Content="Click Me" Background="PaleVioletRed" >
            <Button.Style>
                <Style TargetType="Button">
                    <Style.Triggers>
                    <!--ISMouseOvr is a Dependecy property that triggers iNotify property changed and set valuse of controls -->
                        <Trigger Property="IsMouseOver" Value="True" >
                            <Setter Property="FontSize" Value="50" />
                            <Setter Property="Background" Value="DodgerBlue" />
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
```

+ Create Custom Dependency Property MyPorperty
```c#
   public int MyProperty
        {
            get { return (int)GetValue(dependencyProperty);  }
            set { SetValue(dependencyProperty, value); }
        }

        public static readonly DependencyProperty dependencyProperty = DependencyProperty.Register("MyProperty", typeof(int), typeof(DependencyPropertiesDemo),new PropertyMetadata(0));


```

## 5. Data Binding

+ 4 Modes of Date Binding
+ Binding Target(Xaml) |    way    | Binding Source
1.      Binding Target      <- One Way               Binding Source
2.      Binding Target      <- two Way           ->  Binding Source
3.     Binding Target          One Way to Source ->  Binding Source
  + so that only the Bini 
4.       Binding Target     <- One TIme            Binding Source
 + it  done in constructor so only once during initialization we can set values.


* Demo on Data Binding
 + here we bind text of textbox to slider's value , 
 + in that we can apply different modes of binding 
 + to update changes , we need to click the tab button , but these can be automated using the 
 > UpdateSourceTrigger=PropertyChanged
```xml

    <StackPanel>
             <!-- here in one way,  text will be updated based on slider value -->
       <TextBox x:Name="myText" Width="100" Margin="50" Text="{Binding ElementName=MySlider,Path=Value,Mode=OneWay}" ></TextBox>

             <!-- here in two way,  text will be updated based on slider value as well as slider value will be updated based on text value-->

        <TextBox x:Name="myText" Width="100" Margin="50" Text="{Binding ElementName=MySlider,Path=Value,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" ></TextBox>
        <Slider x:Name="MySlider" IsSnapToTickEnabled="True" Minimum="0" Maximum="100" ></Slider>
    </StackPanel>
```        

## 6.INotifyPropertyChanged Interface
+ it Notifies the client that prperty has changed. in our case UI is the client.
+ here in Sum class we can see how interface is implemented with validation done on private fields
+ now we can set this Sum class object as Datacontext to make it working with UI 
```c#
 public class Sum : INotifyPropertyChanged
    {
        private string num1;

        public string Num1
        {
            get { return num1; }
            set
            {
                int number;
                bool res = int.TryParse(value, out number);
                if (res) num1 = value;
                OnPropertyChanged("Num1");
                OnPropertyChanged("Result");
            }
        }

        private string num2;

        public string Num2
        {
            get { return num2; }
            set
            {
                int number;
                bool res = int.TryParse(value, out number);
                if (res) num2 = value;
                OnPropertyChanged("Num2");
                OnPropertyChanged("Result");
            }
        }

        private string result;

        public string Result
        {
            get {
                int res = int.Parse(Num1) + int.Parse(Num2);

                return res.ToString();
            }
            set {
                int res = int.Parse(Num1) + int.Parse(Num2);

               result = res.ToString();
                OnPropertyChanged("Result");
            }
        }
// Implementing the interface
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }

```

## 7. ListBox
+ same as ListVIew 
+ use to show data in tabular form to user
```xml
  <ListBox x:Name="lbMatches" HorizontalContentAlignment="Stretch"   SelectionMode="Single">
            <ListBox.GroupStyle>         
            </ListBox.GroupStyle>
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Grid Margin="2">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="*" />
                            <ColumnDefinition Width="*" />
                            <ColumnDefinition Width="*" />
                            <ColumnDefinition Width="*" />
                            <ColumnDefinition Width="*" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Grid.Column="0" Text="{Binding Team1}" />
                        <TextBlock Grid.Column="1" Text="{Binding Score1}" />
                        <TextBlock Grid.Column="2" Text="{Binding Team2}" />
                        <TextBlock Grid.Column="3" Text="{Binding Score2}" />
                        <ProgressBar Grid.Column="4" Minimum="0" Maximum="90" Value="{Binding Completion}" />

                    </Grid>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
```

## 8. ComboBox
+ to make selection from a list of items
```xml
   <ComboBox  Name="comboBoxColors">
            <ComboBox.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal">
                        <Rectangle Fill="{Binding Name}" Width="32" Height="32" Margin="5" />
                        <TextBlock Text="{Binding Name}" FontSize="32"/>
                    </StackPanel>
                </DataTemplate>
            </ComboBox.ItemTemplate>
        </ComboBox>
```
+ code behind
+ to get all Colors in Color class we can use typeof(object).GetProperties();
```c#
// to get all Colors in Color class we can use typeof(object).GetProperties();
  comboBoxColors.ItemsSource = typeof(Colors).GetProperties();
```
## 9. CheckBOx
+ to select a option or all from a given selection
+ it can have 3 states: check, uncheck, null
```xml


<CheckBox Name="cbAllToppings" IsThreeState="True" Checked="cbAllToppingsCheckChanged" 
                  Unchecked="cbAllToppingsCheckChanged" >Add All</CheckBox>
        <StackPanel Margin="12,0,0,0">
                <CheckBox Name="cbSalami" Checked="cbSingleCheckChanged"
                          Unchecked="cbSingleCheckChanged">
                    <TextBlock > Salami <Run Foreground="Red" FontWeight="Bold"> Spicy</Run> </TextBlock>
                    
                </CheckBox>

                <CheckBox Name="cbMushroom" Checked="cbSingleCheckChanged"
                          Unchecked="cbSingleCheckChanged">
                    <TextBlock > Mushroom </TextBlock>

                </CheckBox>

                <CheckBox Name="cbOnion" Checked="cbSingleCheckChanged"
                          Unchecked="cbSingleCheckChanged">
                    <TextBlock > Onion</TextBlock>

                </CheckBox>


            </StackPanel>
       
```        

## 10. ToolTip
+ use to provide extra information about the control, avaialable for mostly all controls 

```xml
 <TextBlock Text="CheckBox Demo" FontSize="30" ToolTip="demo on how to use checkboxes"/>
```

## 11. Trggers 
+ in WPF we use trigger with Styles , when we can set a property, event , data as trigger , based on which setters are called
1. **Property Trigger**
 * it is executed when a property changes
 ```xml
 <TextBlock Text="Hello beloved world!" FontSize="32" HorizontalAlignment="Center">
            <TextBlock.Style>
                <Style TargetType="TextBlock">
                    <Setter Property="Foreground" Value="Green" />
                    <Style.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="Foreground" Value="Red" />
                            <Setter Property="TextDecorations" Value="Underline" />
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </TextBlock.Style>
        </TextBlock>
 ```

2. **Event Trigger**
+ we can add animation using EventTrigger.Actions
 ```xml
 <TextBlock Grid.Row="2" Text="Beloved Buddy 2!"  HorizontalAlignment="Center">
            <TextBlock.Style>
                <Style TargetType="TextBlock">
                    <Setter Property="FontSize" Value="32" />
                    <Style.Triggers>
                        <EventTrigger RoutedEvent="MouseEnter">
                            <EventTrigger.Actions>
                                <BeginStoryboard>
                                    <Storyboard>
                                        <DoubleAnimation Duration="0:0:0.500" 
                                                         Storyboard.TargetProperty="FontSize" To="72" />
                                    </Storyboard>
                                </BeginStoryboard>
                            </EventTrigger.Actions>
                        </EventTrigger>

                        <EventTrigger RoutedEvent="MouseLeave">
                            <EventTrigger.Actions>
                                <BeginStoryboard>
                                    <Storyboard>
                                        <DoubleAnimation Duration="0:0:0.300" 
                                                         Storyboard.TargetProperty="FontSize" To="32" />
                                    </Storyboard>
                                </BeginStoryboard>
                            </EventTrigger.Actions>
                        </EventTrigger>
                    </Style.Triggers>
                </Style>
            </TextBlock.Style>
        </TextBlock>
 ```
3. **Data Trigger**
+ we can bind a property value to trigger with Data Trigger
 ```xml
 <CheckBox Grid.Row="3" HorizontalAlignment="Center" FontSize="30" Name="cbHello" Content="Is Someone there?" />
        <TextBlock Grid.Row="4" HorizontalAlignment="Center" FontSize="36" >
            <TextBlock.Style>
                <Style TargetType="TextBlock">
                    <Setter Property="Text" Value="No" />
                    <Setter Property="Foreground" Value="Red" />

                    <Style.Triggers>
                        <DataTrigger Binding="{Binding ElementName=cbHello,Path=IsChecked}" Value="True">
                            <Setter Property="Text" Value="Of Course" />
                            <Setter Property="Foreground" Value="Yellow" />
                        </DataTrigger>
                    </Style.Triggers>   
                </Style>
            </TextBlock.Style>
        </TextBlock>
 ```
## 12. PasswordBox
+ it is used to hide input text from user 
+ we can show different character as password text using passwordChar 
```xml
 <Label> Password</Label>
        <PasswordBox MaxLength="8" PasswordChar="$"></PasswordBox>
```
