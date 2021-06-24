import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { PostService } from './_services/post.service';
import { LargePreviewComponent } from './post/large-preview/large-preview.component';
import { SmallPreviewComponent } from './post/small-preview/small-preview.component';
import { FullPostComponent } from './post/full-post/full-post.component';
import { FilteredPostsComponent } from './post/filtered-posts/filtered-posts.component';
import { AboutComponent } from './about/about.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    LargePreviewComponent,
    SmallPreviewComponent,
    FullPostComponent,
    FilteredPostsComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule
  ],
  providers: [
    PostService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
