import { Component, Input, OnInit } from '@angular/core';
import { Post } from 'src/app/_models/post';

@Component({
  selector: 'app-large-preview',
  templateUrl: './large-preview.component.html',
  styleUrls: ['./large-preview.component.css']
})
export class LargePreviewComponent implements OnInit {
  @Input() postFromHomeComponent?: Post;
  bodyPreview?: string;
  subtitlePreview?: string;
  titlePreview?: string;

  constructor() { }

  ngOnInit(): void {
    this.bodyPreview = this.postFromHomeComponent?.paragraphs[0].substr(0, 750) + "...";
    this.subtitlePreview = this.postFromHomeComponent?.subtitle.substr(0, 50);
    this.titlePreview = this.postFromHomeComponent?.title.substr(0, 50);
  }

}
