import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-filtered-posts',
  templateUrl: './filtered-posts.component.html',
  styleUrls: ['./filtered-posts.component.css']
})
export class FilteredPostsComponent implements OnInit {
  type: string | null = "movie";

  constructor(private route: ActivatedRoute, private router: Router) {
    this.loadType();
  }

  ngOnInit(): void {
    
  }

  loadType() {
    this.type = this.route.snapshot.paramMap.get('type');
  }

}
