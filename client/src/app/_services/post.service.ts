import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Post } from '../_models/post';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  baseUrl = environment.apiUrl + 'post/';

  constructor(private http: HttpClient) { }

  pullPosts() {
    return this.http.get<Post[]>(this.baseUrl);
  }

}
