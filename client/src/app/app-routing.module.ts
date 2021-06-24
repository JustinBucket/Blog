import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { HomeComponent } from './home/home.component';
import { FilteredPostsComponent } from './post/filtered-posts/filtered-posts.component';
import { FullPostComponent } from './post/full-post/full-post.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'fullpost/:id', component: FullPostComponent},
  {path: 'filtered/:type', component: FilteredPostsComponent},
  {path: 'about', component: AboutComponent},
  {path: '**', component: HomeComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
