import { Component, OnInit } from '@angular/core';
import { Product } from '../../models/product';
import { Category } from '../../models/category';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';
import { CategoryService } from '../../services/category.service';
import { ProductService } from '../../services/product.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  products: Product[] = [];
  categories: Category[] = []; // Dữ liệu động từ categoryService
  selectedCategoryId: number  = 0; // Giá trị category được chọn
  currentPage: number = 1;
  itemsPerPage: number = 6;
  pages: number[] = [];
  totalPages:number = 0;
  visiblePages: number[] = [];
  keyword:string = "";

  constructor(
    private productService: ProductService,
    private categoryService: CategoryService,
    private router: Router,
    ) {}

    ngOnInit() {
      this.currentPage = Number(localStorage.getItem('currentProductPage')) || 0;
      this.getProducts(this.keyword, this.selectedCategoryId, this.currentPage, this.itemsPerPage);
      this.getCategories();
    }

    getCategories() {
      this.categoryService.getCategories().subscribe({
        next: (categories: Category[]) => {
          debugger;
          this.categories = categories;
          console.log(this.categories);
        },
        complete: () => {
          debugger;
        },
        error: (error: any) => {
          console.error('Error fetching categories:', error);
        }
      });
    }

    searchProducts() {
      this.currentPage = 1;
      this.itemsPerPage = 6;
      debugger;
      this.getProducts(this.keyword, this.selectedCategoryId, this.currentPage, this.itemsPerPage);
      console.log(this.selectedCategoryId);
      debugger
    }

    getProducts(keyword: string, category_id : number,  page: number, limit: number) {
      debugger;
      this.productService.getProducts(keyword, category_id, page, limit).subscribe({
        next: (response:any) => {
          this.products = response.productsList;
          console.log(this.products);
          debugger;
          this.totalPages = response.totalPage;
          console.log(this.totalPages);
          this.products.forEach((product: Product) => {
            console.log(product.thumbnail);
            product.url = `https://localhost:7012/api/ProductImage/images/${product.thumbnail}`;
           console.log(product.url);
          });
          debugger;
          this.visiblePages = this.generateVisiblePageArray(this.currentPage, this.totalPages);
        },
        complete: () => {
          debugger;
        },
        error: (error: any) => {
          debugger;
          console.error('Error fetching products:', error);
        }
      });
    }
    onPageChange(page: number) {
      debugger;
      let page_now = page+1;
      this.currentPage = page_now < 0 ? 0 : page_now;
      localStorage.setItem('currentProductPage', String(this.currentPage));
      debugger
      this.getProducts(this.keyword, this.selectedCategoryId, this.currentPage, this.itemsPerPage);
      debugger
    }

    generateVisiblePageArray(currentPage: number, totalPages: number): number[] {
      const maxVisiblePages = 5;
      const halfVisiblePages = Math.floor(maxVisiblePages / 2);
      debugger
      let startPage = Math.max(currentPage - halfVisiblePages, 1);
      let endPage = Math.min(startPage + maxVisiblePages - 1, totalPages);
      debugger
      if (endPage - startPage + 1 < maxVisiblePages) {
        startPage = Math.max(endPage - maxVisiblePages + 1, 1);
      }
      debugger
      return new Array(endPage - startPage + 1).fill(0)
        .map((_, index) => startPage + index);
    }

    // Hàm xử lý sự kiện khi sản phẩm được bấm vào
    onProductClick(productId: number) {
      debugger;
      // Điều hướng đến trang detail-product với productId là tham số
      this.router.navigate(['/products', productId]);
    }
}
