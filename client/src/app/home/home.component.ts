import { Component, OnInit } from '@angular/core';
import { Post } from '../_models/post';
import { PostService } from '../_services/post.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  posts?: Post[];
  mainPost?: Post;

  // we want to have the latest post to be featured, and all the others make up the lower region
  // let's leave this for later

  constructor(private postService: PostService) { }

  ngOnInit(): void {
    this.pullPosts();
  }

  pullPosts() {
    this.postService.pullPosts().subscribe(response => {
      this.posts = response.sort((a: Post, b: Post) => {
        // wow javascript sucks
        return new Date(b.creationDate).getTime() - new Date(a.creationDate).getTime()
      });
      this.mainPost = this.posts[0];
      this.posts = this.posts.slice(1);
    });
  }
}
