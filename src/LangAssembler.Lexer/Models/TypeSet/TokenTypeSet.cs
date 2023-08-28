﻿using System.Collections;
using LangAssembler.Lexer.Models.Type;
using LangAssembler.Lexer.Providers;

namespace LangAssembler.Lexer.Models.TypeSet;

/// <summary>
/// An abstract base class that represents a set of token types.
/// </summary>
public abstract class TokenTypeSet : ITokenTypeSet
{

    /// <summary>
    /// Initializes a new instance of the TokenTypeSet class and adds it to the TokenSetProvider.
    /// </summary>
    protected TokenTypeSet()
    {
        TokenSetProvider.AddSet(this);
    }
    
    /// <summary>
    /// Field to hold a collection of token types.
    /// </summary>
    private IEnumerable<ITokenType>? _types;
    
    
    /// <summary>
    /// Initializes the collection of token types. The method must be overridden in a derived class.
    /// </summary>
    /// <returns>A collection of token types.</returns>
    protected abstract IEnumerable<ITokenType> InitializeTypes();

    /// <summary>
    /// A private helper method to generate an enumerator for token types.
    /// </summary>
    /// <returns>Enumerator of token types.</returns>
    private IEnumerator<ITokenType> TypeEnumerator() =>
        _types is { } types ? types.GetEnumerator() : (_types = InitializeTypes()).GetEnumerator();
    
    /// <summary>
    /// Gets an enumerator for the token types.
    /// </summary>
    /// <returns>Enumerator of token types.</returns>
    public IEnumerator<ITokenType> GetEnumerator() => TypeEnumerator();
    
    /// <summary>
    /// Gets a non-generic enumerator for the token types.
    /// </summary>
    /// <returns>Enumerator of token types.</returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}