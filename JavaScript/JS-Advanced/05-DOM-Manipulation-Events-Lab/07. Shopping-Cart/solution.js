function solve() {
   let addProductButtonElements = Array.from(document.getElementsByClassName('product-add'));
   let checkoutButtonElement = document.querySelector('button[class=checkout]');
   let textAreaElement = document.querySelector('textarea');

   let products = [];

   addProductButtonElements.forEach(addButton => {
      addButton.addEventListener('click', addToCartEventHandler);
   });

   checkoutButtonElement.addEventListener('click', checkoutEventHandler, { once: true });

   function addToCartEventHandler(e) {
      if (!e.currentTarget.disabled) {
         let productDivElement = e.currentTarget.parentElement;

         let title = productDivElement.querySelector('.product-title').textContent;
         let price = Number(productDivElement.querySelector('.product-line-price').textContent).toFixed(2);

         const product = { title, price };
         products.push(product);

         textAreaElement.value += `Added ${title} for ${price} to the cart.\n`;;
      }
   }

   function checkoutEventHandler() {
      addProductButtonElements.forEach(btn => {
         btn.disabled = true;
      })

      const productTitles = [...new Set(products.map(x => x.title))];
      const totalPrice = products
         .map(x => Number(x.price))
         .reduce((acc, cur) => acc += cur)

      textAreaElement.value += `You bought ${productTitles.join(', ')} for ${totalPrice.toFixed(2)}.`
   }
}