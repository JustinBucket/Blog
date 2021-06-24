import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Post } from 'src/app/_models/post';
import { PostService } from 'src/app/_services/post.service';

@Component({
  selector: 'app-full-post',
  templateUrl: './full-post.component.html',
  styleUrls: ['./full-post.component.css']
})
export class FullPostComponent implements OnInit {
  fullPost?: Post;

  constructor(private postService: PostService, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.loadPost();
  }

  loadPost() {
    this.postService.pullPost(parseInt(this.route.snapshot.paramMap.get('id') || "")).subscribe(post => {
      this.fullPost = post;
    })
  }

}
