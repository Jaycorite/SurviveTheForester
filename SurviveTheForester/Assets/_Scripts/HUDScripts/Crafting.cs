using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{

    public Sprite craftingSlotImage;
    List<GameObject> recipePages;
    public RecipeBook recipeBook;
    public Button Left, Right;
    InventoryUI inventory;

    int pageIndex = 1;
    //EventSystem eventSystem;

    //public TextMeshPro text;
    public TextMeshProUGUI text2;

    Mouse mouse;
    // Start is called before the first frame update
    void Start()
    {
        //events = new List<EventTrigger>();
        //eventSystem = gameObject.AddComponent<EventSystem>();
        //LoadCraftingMenu();
        //AddRecipeToMenu(recipeBook.Recipes);
        GameObject sibling = transform.parent.Find("Inventory").gameObject;
        inventory = sibling.GetComponent<InventoryUI>();
        Debug.Log(inventory.name);

        text2.text = MakeRecipeText(recipeBook.Recipes[pageIndex-1]);

        //hmm();
    }

    // Update is called once per frame
    void Update()
    {
    }
    


    private string MakeRecipeText(Recipe recipe)
    {
        string text = "";
        text += recipe._item.name;
        text += "\n";
        text += recipe.description;
        text += "\n";
        text += "\n";
        text += "Ingredients";
        text += "\n";

        foreach (var v in recipe.IngredientsList())
        {
            text += v.name;
            text += "\n";
        }

        return text;
    }

    public void GoLeft()
    {
        Debug.Log("LEEFt");
        if (pageIndex > 1)
        {
            pageIndex--;
            text2.text = MakeRecipeText(recipeBook.Recipes[pageIndex-1]);
        }
    }

    public void Craft()
    {

        List<GameObject> Items = inventory.RequestItems(recipeBook.Recipes[pageIndex-1].IngredientsList());

        if (Items.Count == recipeBook.Recipes[pageIndex-1]._recipe.Count)
        {

            Items.ForEach(x => Destroy(x));
            GameObject item = Instantiate(recipeBook.Recipes[pageIndex - 1]._item);
            item.name = item.name.Substring(0, recipeBook.Recipes[pageIndex - 1]._item.name.Length);
            item.SetActive(true);
            inventory.AddItem(item);
            Debug.Log("CRAFTING");
        }
        else
        {
            Debug.Log("Not CRAFTING");
        }
    }

    public void GoRight()
    {
        Debug.Log("Right recipeBook.Recipes.Count");
        Debug.Log(recipeBook.Recipes.Count);
        if (pageIndex < recipeBook.Recipes.Count)
        {
            pageIndex++;
            text2.text = MakeRecipeText(recipeBook.Recipes[pageIndex-1]);
        }
    }
    private void LoadRecipes() 
    {

    }

    private void AddRecipeToMenu(List<Recipe> recipes)
    {
        foreach(Recipe r in recipes)
        {
            GameObject page = new GameObject();
            page.transform.SetParent(transform);
            page.AddComponent<RectTransform>();
            page.AddComponent<CanvasRenderer>();
            page.AddComponent<Button>();
            page.AddComponent<Image>();
            page.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(1f, 1f);

            GameObject button = new GameObject();
            button.AddComponent<Button>();
            button.AddComponent<Image>();
            button.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(1f, 1f);
            button.transform.SetParent(page.transform);


            RectTransform rect = page.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(1, 1);


        }
    }
    

    public void LoadCraftingMenu()
    {
        int SlotCounter = 1;
        float offX = -116, offY = -120, offChange = 120;
        for (int rows = 0; rows < 4; rows++)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject o = new GameObject("Crafting Slot" + SlotCounter);
                o.AddComponent<RectTransform>();
                o.AddComponent<CanvasRenderer>();
                o.AddComponent<BoxCollider2D>();

                o.tag = "InventorySlot";

                o.transform.SetParent(this.transform);
                o.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.transform.position.x + (offX + (offChange * i)), this.transform.position.y + (offY*rows));

                RectTransform rect = o.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(1, 1);

                o.AddComponent<Image>();
                o.GetComponent<Image>().sprite = craftingSlotImage;
                Color color = new Color(0.5f, 0.5f, 0.3f);
                o.GetComponent<Image>().color = color;
                o.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(1f, 1f);
                o.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(0f + (offX + (offChange * i)), 180 + (offY * rows));

                SlotCounter++;
            }
        }
        
    }

}
