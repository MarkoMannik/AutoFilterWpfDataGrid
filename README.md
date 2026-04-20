# AutoFilterWpfDataGrid  
### Advanced automatic filtering for WPF DataGrid (.NET 8)

**AutoFilterWpfDataGrid** adds automatic, type‑aware filter controls to every DataGrid column —  
no templates, no converters, no manual UI work.

It is a production‑ready WPF control that enhances the standard DataGrid with powerful filtering and optional numeric summaries.


## 📦 ZIP package contents

```
AutoFilterWpfDataGrid/
│
├── lib/
│   ├── AutoFilterWpfDataGrid.dll
│   └── AutoFilterWpfDataGrid.xml   (XML documentation)
│
└── demo/
    ├── AutoFilterWpfDataGridDemo.sln

```

---

## 🚀 Features

- **Automatic filter controls** in column headers  
- **Text filters**
- **Numeric filters (From/To)**
- **Boolean filters (CheckBox)**
- **Enum filters (multi‑select)**
- **Date filters (From/To)**
- **TimeSpan filters (From/To)**
- **Guid filters**
- **Nullable type support** (“No value”)
- **Automatic column header generation**
- **Optional custom header mapping**
- **Automatic numeric column sum (∑)**
- **FiltersChanged event**
- **Pure WPF, zero dependencies**
- **Works with List / ObservableCollection / BindingList**

---

## 🔑 Licensing

AutoFilterWpfDataGrid works in **FREE MODE** by default:

- **Free mode limitation:** only **1 filter** can be active at a time.

To unlock unlimited filtering, set your license key:

```csharp
AutoFilterWpfDataGridDemo.LicenseKey = "YOUR LICENSE KEY HERE";
```

You will receive your license key by email after purchase.

---

## 🛠 Installation

### **Option 1 — Add DLL manually**

1. Open your WPF project  
2. Right‑click **References → Add Reference…**  
3. Click **Browse** and select:

```
lib/AutoFilterWpfDataGrid.dll
```

4. Ensure **Copy Local = True**

---

### **Option 2 — Copy DLL into your project**

Copy the DLL into a folder such as:

```
/libs/AutoFilterWpfDataGrid.dll
```

Then add a reference to it.

---

## 🧩 Basic Usage

### **XAML**

```xml
<Window
    xmlns:local="clr-namespace:AutoFilterWpfDataGrid;assembly=AutoFilterWpfDataGrid">
    <local:AutoFilterWpfDataGrid x:Name="MyAutoFilterWpfDataGrid" Loaded="MyAutoFilterWpfDataGrid_Loaded"/>
</Window>
```

---

### **Code‑behind**

```csharp
public MainWindow()
{
    InitializeComponent();

    // Add your license key here
    MyAutoFilterWpfDataGrid.LicenseKey = "YOUR LICENSE KEY HERE";
}

private void MyAutoFilterWpfDataGrid_Loaded(object sender, RoutedEventArgs e)
{
    //Set your ItemsSource. AutoFilterWpfDataGrid will generate filters for supported types
    MyAutoFilterWpfDataGrid.ItemsSource = GetYourData();            
}

```

---

## ⚙ Optional Configuration

### **Custom column headers**

```csharp
MyAutoFilterWpfDataGrid.PropertyHeaderMapList = new List<PropertyHeaderMap>
{
    new PropertyHeaderMap("Name", "First Name"),
    new PropertyHeaderMap("DateOfBirth", "D.O.B"),
    new PropertyHeaderMap("YOUR-PROPERTY-NAME", "YOUR-DESIRED-HEADER")
};
```

---

### **Show sum only on specific columns**

```csharp
MyAutoFilterWpfDataGrid.ShowSumInHeadersPropertyList = new List<string>
{
    "NetIncome",
    "YOUR-DESIRED-PROPERTY-WHERE-YOU-WANT-SUM"
};
```

---

### **Disable all sums**

```csharp
MyAutoFilterWpfDataGrid.ShowSumsInHeaders = false;
```

---

### **Disable “No value” checkbox**

```csharp
MyAutoFilterWpfDataGrid.ShowNoValueFilterCheckBox = false;
```

---

### **FiltersChanged event**

```csharp
private void MyAutoFilterWpfDataGrid_FiltersChanged(object sender, RoutedEventArgs e)
{
    var nameFilter = MyGrid.Filters
        .Where(f => f.PropertyName == "Name")
        .Select(f => f.StringValue)
        .FirstOrDefault();
}
```

---

## 🧪 Demo Application

The `demo/` folder contains a fully working WPF demo project showing:

- AutoFilterWpfDataGrid (free mode)  
- Regular DataGrid for comparison  
- All supported data types  
- Example configuration  

Open:

```
demo/AutoFilterWpfDataGridDemo.sln
```

and run the project.
