import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectHeroComponent } from './select-hero.component';

describe('SelectHeroComponent', () => {
  let component: SelectHeroComponent;
  let fixture: ComponentFixture<SelectHeroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SelectHeroComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SelectHeroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
