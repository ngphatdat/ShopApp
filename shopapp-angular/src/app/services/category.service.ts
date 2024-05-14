import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Category } from '../models/category';
import { UpdateCategoryDTO } from '../dtos/category/update.category.dto';
import { InsertCategoryDTO } from '../dtos/category/insert.category.dto';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private apiBaseUrl = environment.apiBaseUrl;

  constructor(private http: HttpClient) { }
  getCategories():Observable<Category[]> {
    // const params = new HttpParams()
    //   .set('page', page.toString())
    //   .set('limit', limit.toString());
      return this.http.get<Category[]>(`${environment.apiBaseUrl}category`, );
  }
  // getDetailCategory(id: number): Observable<Category> {
  //   return this.http.get<Category>(`${this.apiBaseUrl}/category/${id}`);
  // }
  // deleteCategory(id: number): Observable<string> {
  //   debugger
  //   return this.http.delete<string>(`${this.apiBaseUrl}/category/${id}`);
  // }
  updateCategory(id: number, updatedCategory: UpdateCategoryDTO): Observable<UpdateCategoryDTO> {
    return this.http.put<Category>(`${this.apiBaseUrl}/category/${id}`, updatedCategory);
  }
  // insertCategory(insertCategoryDTO: InsertCategoryDTO): Observable<any> {
  //   // Add a new category
  //   return this.http.post(`${this.apiBaseUrl}/category`, insertCategoryDTO);
  // }
}
